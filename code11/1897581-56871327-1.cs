    using System;
    using System.IO;
    
    namespace FileExercise
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = @"C:\Text.txt";    
                //Read all lines
                string lines = File.ReadAllText(path);
    
                Console.WriteLine(lines);
                //Add line to original document
                File.AppendAllLines(@path, new string[] { "" + "This line is added 
                by Visual Studio" });    
                lines = File.ReadAllText(path);
    
                //Read new lines
                Console.WriteLine(lines);
    
                Console.ReadKey();
            }
        }
    }
