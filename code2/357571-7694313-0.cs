        static void Main(string[] args)
        {
            List<string> test;
            test = Enumerable.Range(1, 31).Select(n => n.ToString()).ToList();
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
