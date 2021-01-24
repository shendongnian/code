        static void Main(String[] args)
        {
            List<string> examples = new List<string>();
            for(int i=1;i<=12;i++)
            {
                examples.Add($"Example {i}");
            }
            examples.Shuffle();
            var firstlist = examples.Take(examples.ToArray().Length / 2).ToArray();
            Console.WriteLine(String.Join(", ", firstlist));
            var secondlist = examples.Skip(examples.ToArray().Length / 2).ToArray();
            Console.WriteLine(String.Join(", ", secondlist));
            Console.ReadLine();
        }
