    class Program
    {
        static void Main(string[] args)
        {
            var driveslist = new[] {"C"};
            
            foreach (var drivename in driveslist)
            {
                string[] files = Directory.GetFiles($"{drivename}:\\", "*.*");
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
            Console.ReadLine();
        }
    }
