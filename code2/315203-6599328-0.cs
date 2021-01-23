        namespace ConsoleApplication1
        {
        class Program
        {
            static void Main(string[] args)
            {
                var content = new string[] { "Cat, Animal, 2", "Dog, Animal, 3", "Luke, Human, 1", "Owl, Animal, 0" };
                foreach (var item in content)
                {
                    Console.WriteLine(IncrementIfKeywordFound(item, "Animal"));
                }
                Console.ReadLine();
            }
            private static string IncrementIfKeywordFound(string data, string keyword)
            {
                var parts = data.Split(new [] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts[1] == keyword) parts[2] = (Convert.ToInt32(parts[2]) + 1).ToString();
                return string.Join(", ", parts);
            }
        }
    }
