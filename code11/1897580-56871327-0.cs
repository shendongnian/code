    using System;
    using System.IO;
    
    namespace FileExercise
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Find file path and see if it exists
                string path = @"C:\Text.txt";
    
                if (File.Exists(path))
    
                {
                    Console.WriteLine("File exists");
                }
    
                System.Threading.Thread.Sleep(3000);
    
                //Read all lines
                string lines;
    
                lines = File.ReadAllText(path);
    
                Console.WriteLine(lines);
    
                System.Threading.Thread.Sleep(3000);
    
                //Add line to original document
                File.AppendAllLines(@path, new string[] { "" + "This line is added 
                by Visual Studio" });
    
                System.Threading.Thread.Sleep(10000);
                lines = File.ReadAllText(path);
    
                //Read new lines
                Console.WriteLine(lines);
    
                Console.ReadKey();
            }
        }
    }
