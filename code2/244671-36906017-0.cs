            Dictionary<string, int> first = new Dictionary<string, int>();
            Dictionary<int, string> second = new Dictionary<int, string>();
            first.Add("a", 1);
            first.Add("c", 3);
            first.Add("b", 2);
            first.Add("g", 7);
            first.Add("d", 4);
            second.Add(3, "c");
            second.Add(1, "a");
            second.Add(7, "g");
            second.Add(2, "b");
            second.Add(4, "d");
            Dictionary<string, int> final = new Dictionary<string, int>();
            second.ToList().ForEach(s =>
            {
                if (first.ContainsValue(s.Key))
                    final.Add(s.Value, s.Key);
            });
            foreach (var item in final)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
