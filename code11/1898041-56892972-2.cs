            Dictionary<int, string> map = new Dictionary<int, string>();
            map.Add(256, "OI");
            map.Add(302, "OI");
            map.Add(303, "N2");
            map.Add(304, "N2.5");
            map.Add(400, "N2");
            var minDiffGroup = map.SelectMany(item1 =>
                 map
                 .Where(item2 => !object.Equals(item1, item2))
                 .Select(item2 => new { Diff = Math.Abs(item1.Key - item2.Key), Item1 = item1, Item2 = item2 })
              )
              .GroupBy(item => item.Diff)
              .OrderBy(group => group.Key)
              .FirstOrDefault();
            Console.WriteLine("Diff: {0}", minDiffGroup.Key);
            foreach (var item in minDiffGroup)
                Console.WriteLine("Item 1: {0}\tItem 2:{1}", item.Item1, item.Item2);
            Console.ReadKey();
