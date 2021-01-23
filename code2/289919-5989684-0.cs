    void Main()
    {
        var list = Enumerable.Range(1, 9)
            .Select(i => new { V = i, P = i })
            .ToArray();
        list.Dump("list");
        
        var sum =
            (from element in list
             select element.P).Sum();
        
        Dictionary<int, int> selected = new Dictionary<int, int>();
        foreach (var value in Enumerable.Range(0, sum))
        {
            var temp = value;
            var v = 0;
            foreach (var element in list)
            {
                if (temp < element.P)
                {
                    v = element.V;
                    break;
                }
                
                temp -= element.P;
            }
            Debug.Assert(v > 0);
            if (!selected.ContainsKey(v))
                selected[v] = 1;
            else
                selected[v] += 1;
        }
        
        selected.Dump("how many times was each value selected?");
    }
