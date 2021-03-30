using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace bai2
{
    class Program
    {
        public class EnDeCodeDirInfo
        {
            static string RemoveRootPath(string rootPath, string fileName)
            {
                return fileName.Remove(0, rootPath.Length + 1);
            }
            public string encode(string path)
            {

                string[] DirEntries = Directory.GetDirectories(path);
                string[] FileEntries = Directory.GetFiles(path);
                string Result = "";
                if (!Directory.Exists(path))
                {
                    return "thu muc khong ton tai";
                }
                foreach (string Name in DirEntries)
                {
                    Result = String.Join(RemoveRootPath(path, Name), Result, ";0;");
                }

                foreach (string Name in FileEntries)
                {
                    Result = String.Join(RemoveRootPath(path, Name), Result, ";1;");
                }
                Result = '$' + Result.TrimEnd(';') + '#';
                return Result;
            }
            public string decode(string S)
            {
                string Result = "";
                S = S.Substring(1, S.Length - 2);
                string[] list = S.Split(';');
                for (int i = 0; i < list.Length; i += 1)
                {
                    if (i % 2 == 0) Result = Result + list[i] + " ";
                }
                return Result;
            }
        }
        static void Main(string[] args)
        {
            EnDeCodeDirInfo enDeCodeDirInfo = new EnDeCodeDirInfo();
            Console.WriteLine(enDeCodeDirInfo.encode(@"E:\HocTap\Lap Trinh Mang\baiMau\bai2\Folder"));
            Console.WriteLine(enDeCodeDirInfo.decode("$folder1;0;folder2;0;text1.txt;1;text2.txt;1#"));
        }
    }
    
}
