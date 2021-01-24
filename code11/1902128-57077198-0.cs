        List<Tuple<string, string, string>> list = new List<Tuple<string, string, string>>();
        list.Add(Tuple.Create("Cars", "Bird", "1.0"));
        list.Add(Tuple.Create("Plane", "Flower", "1.0"));
        list.Add(Tuple.Create("Cars", "Bird", "2.0"));
        list.Add(Tuple.Create("Plane", "Flower", "2.0"));
        foreach (var group in list.GroupBy(tuple => tuple.Item1))
        {
            Console.WriteLine(group.Key);
            foreach (var tuple in group)
            {
                Console.WriteLine("  " + tuple);
            }
        }
