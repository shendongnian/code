    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Name");
            string name = Console.ReadLine();
            Console.WriteLine("Lastname");
            string lastname = Console.ReadLine();
        
            // set the number of required sets and size
            const int sets = 10;
            const int size = 2;
            // make both inputs long enough
            var input1 = string.Concat(Enumerable.Repeat(name, (Math.Abs((sets * size) / name.Length) + 1)));
            var input2 = string.Concat(Enumerable.Repeat(lastname, (Math.Abs((sets * size) / lastname.Length) + 1)));
            // enumerate the index so we can substring the inputs.    
            var results = Enumerable.Range(0, sets)
                .Select(x => $"{x + 1}{input1.Substring(x * size, size)}{input2.Substring(x * size, size)}");
            // optional write to console
            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
