        var rows = new List<List<int>>(){
                new List<int>(){1, 2, 3},
                new List<int>(){4, 5, 6},
                new List<int>(){7, 8, 9},
                new List<int>(){3, 2, 1}};
 
        var averages = new List<double>();
        foreach(var list in rows)
        {
            var diffs = new List<int>();
            for (int i = 0; i < list.Count - 1; i++)
                for (int j = i+1; j < list.Count; j++)
                    diffs.Add(Math.Abs(list[i]-list[j]));
            averages.Add(diffs.Average());
        }
        averages.ForEach(i=>Console.WriteLine(i));
        Console.WriteLine("Minimum average is " + averages.Min());
