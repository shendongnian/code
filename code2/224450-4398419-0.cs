        static void Main(string[] args)
        {
            int partLength = 35;
            string sentence = "Silver badges are awarded for longer term goals. Silver badges are uncommon.";
            string[] words = sentence.Split(' ');
            var parts = new Dictionary<int, string>();
            string part = string.Empty;
            int partCounter = 0;
            foreach (var word in words)
            {
                if (part.Length + word.Length < partLength)
                {
                    part += string.IsNullOrEmpty(part) ? word : " " + word;
                }
                else
                {
                    parts.Add(partCounter, part);
                    part = word;
                    partCounter++;
                }
            }
            parts.Add(partCounter, part);
            foreach (var item in parts)
            {
                Console.WriteLine("Part {0} (length = {2}): {1}", item.Key, item.Value, item.Value.Length);
            }
            Console.ReadLine();
        }
