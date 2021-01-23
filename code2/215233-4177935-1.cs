    using System.IO;
    
    class Program
    {
        static void Main()
        {
            string filepath = @"C:\Users\Sam\Documents\Test.txt";
    
            string extension = Path.GetExtension(filepath);
            if (extension  == ".mp3")
            {
                Console.WriteLine(extension);
            }
        }
    }
