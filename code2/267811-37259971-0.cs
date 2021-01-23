        static void Main(string[] args)
        {
            var dict = new Dictionary<int, string>
            {
                {3, "ABC"},
                {7, "HHDHHGKD"}
            };
            bool found = false;
            var entry = dict.FirstOrDefault(d => d.Key == 3 && (found=true));
            if (found)
            {
                Console.WriteLine("found: " + entry.Value);
            }
            else
            {
                Console.WriteLine("not found");
            }
            Console.ReadLine();
        }
