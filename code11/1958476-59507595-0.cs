    static void Main(string[] args)
        {
            List<List<string>> lst = new List<List<string>>();
            string[] lines = new string[0];
            lines = File.ReadAllLines("tableX.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
            for (int j = 0; j < lines.Length; j++)
            {
                var line = lines[j].Split(' ').ToList();
                lst.Add(line);
            }
            foreach (var item in lst)
            {
                for (int k = 0; k < item.Count; k++)
                {
                    Console.WriteLine(item[k]);
                }
            }
        }
