    using System;
    using System.IO;
    using System.Text;
    namespace ConsoleApp1
    {
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("APP START");
            string inputDirectory = @"C:\Import\";
            string outputDirectory = @"C:\Output\";
            FileStream stream = File.Create(outputDirectory + "report.txt");
            string [] folders = Directory.GetDirectories(inputDirectory);
            
            foreach(String path in folders)
            {
                Directory.CreateDirectory(path.Replace(inputDirectory, outputDirectory)); 
                string[] files = Directory.GetFiles(path);
                foreach (String file in files)
                {
                    String record = ConvertPathToReportFormat(file);
                    stream.Write(Encoding.UTF8.GetBytes(record), 0, record.Length);
                    File.Copy(file, file.Replace(inputDirectory, outputDirectory));
                }
            }
            stream.Close();
            Console.WriteLine("DONE");
            Console.ReadKey();
        }
        private static String ConvertPathToReportFormat(string path)
        {
            string [] splitedPath = path.Split('\\');
            string[] splitedName = splitedPath[splitedPath.Length - 1].Split('.');
            String folder = splitedPath[splitedPath.Length - 2];
            String name = splitedName[0];
            String extension = splitedName[1];
            return String.Format("{0}:{1}:{2}.{3}\n", folder, name, name, extension);
        }
    }
    }
