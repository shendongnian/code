    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var path = @"C:\test.txt";
                var root = @"C:\";
    
                var pathWithoutRoot = path.Remove(0, root.Length);
                Console.WriteLine(pathWithoutRoot);
    
                pathWithoutRoot = Path.GetFileName(path);
                Console.WriteLine(pathWithoutRoot);
    
                pathWithoutRoot = path.Replace(root, "");
                Console.WriteLine(pathWithoutRoot);
    
                pathWithoutRoot = path.Substring(root.Length);
                Console.WriteLine(pathWithoutRoot);
                
                var pattern = "C:\\\\";
                var regex = new Regex(pattern);
                
                pathWithoutRoot = regex.Replace(path, "");
                Console.WriteLine(pathWithoutRoot);
            }
        }
    }
