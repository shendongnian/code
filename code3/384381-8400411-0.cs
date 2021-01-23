            var lists = new List<List<string>>
            {
                new List<string> { "1", "2", "3", "4" },
                new List<string> { "5", "6", "7", "8" },
                new List<string> { "9", "10", "11", "12" },
            };
            var indexes = new List<int> { 0, 2 };
            var result = lists.Select(l => indexes.Select(i => l[i]).ToList()).ToList();
            foreach (var list in result)
            {
                Console.Write("list:");
                foreach (var elt in list)
                {
                    Console.Write(elt + ",");
                }
                Console.Write(" / ");
            }
