    using System.Linq;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("c:/data.txt");
            var ascending = false;
            var chosen = false;
            do
            {
                Console.WriteLine("Please choose between ascending and descending order.");
                Console.WriteLine("Press 1 for ascending");
                Console.WriteLine("Press 2 for descending");
                var choice = ReadKey(true);
                switch (choice.Key)
                {
                    case ConsoleKey.D1:
                        ascending = true;
                        chosen = true;
                        break;
                    case ConsoleKey.D2:
                        ascending = false;
                        chosen = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (!chosen);
            var sequence = ascending 
                ? lines.OrderBy(x => x) 
                : lines.OrderByDescending(x => x);
            foreach (var line in sequence)
            {
                Console.WriteLine(line);
            }
        }
    }
