    using System;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string serialNum = "MS001";
                string userName = Environment.UserName;
                string sourcecpath = "C:\\Users\\" + userName + "\\Desktop\\Dummy\\Local C";
                string targetcpath = "C:\\Users\\" + userName + "\\Desktop\\Dummy\\Desktop\\" + serialNum + "\\Local C";
                copy(sourcecpath, targetcpath);
            }
        public static void copy(string source, string target)
        {
            string[] systemdir = new string[] { "Error", "Intel", "PerfLogs", "Program Files", "Users", "Windows" };
            for (var i = 0; i < systemdir.Length; i++)
            {
                systemdir[i] = source + "\\" + systemdir[i] + "\\";
                Console.WriteLine(systemdir[i]);
            }
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            {
                string dirPath2 = dirPath + "\\";
                if (!systemdir.Any(dirPath2.Contains))
                {
                    if (System.IO.Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath.Replace(source, target));
                    }
                }
            }
            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
            {
                if (System.IO.Directory.Exists(Path.GetDirectoryName(newPath.Replace(source, target))))
                {
                    if (System.IO.File.Exists(newPath))
                    {
                        File.Copy(newPath, newPath.Replace(source, target), true);
                        // Use a try block to catch IOExceptions, to
                        // handle the case of the file already being
                        // opened by another process.
                        try
                        {
                            System.IO.File.Delete(newPath);
                        }
                        catch (System.IO.IOException e)
                        {
                            Console.WriteLine(e.Message);
                            return;
                        }
                    }
                }
            }
        }
    }
