    using System;
    using System.IO;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            var data = File
                .ReadAllLines("test.txt")
                .Select(x => x.Split('='))
                .Where(x => x.Length > 1)
                .ToDictionary(x => x[0], x => x[1]);
    
            Console.WriteLine("profile: {0}", data["profile"]);
            Console.WriteLine("birthday: {0}", data["birthday"]);
            Console.WriteLine("manufacturer: {0}", data["manufacturer"]);
        }
    }
