using System;
using System.IO;
namespace FileSystemUtils
{
    class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "C:\\docs";
            DirectoryInfo startDir = new DirectoryInfo(folderPath);
            RecurseFileStructure recurseFileStructure = new RecurseFileStructure();
            recurseFileStructure.TraverseDirectory(startDir);
        }
        public class RecurseFileStructure
        {
            public void TraverseDirectory(DirectoryInfo directoryInfo)
            {
                var subdirectories = directoryInfo.EnumerateDirectories();
                foreach (var subdirectory in subdirectories)
                {
                    TraverseDirectory(subdirectory);
                }
                var files = directoryInfo.EnumerateFiles();
                foreach (var file in files)
                {
                    HandleFile(file);
                }
            }
            void HandleFile(FileInfo file)
            {
                Console.WriteLine("{0}", file.Name);
            }
        }
    }
}
