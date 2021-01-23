    class Program
    {
        static void Main(string[] args)
        {
            var set = new HashSet<string>();
            set.Add("one");
            set.Add("two");
            set.Add("three");
            var count = string.Join(", ", set);
            Console.WriteLine(count);
            Console.ReadKey();
        }
    }
