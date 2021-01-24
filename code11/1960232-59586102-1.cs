    static void Arrays(ref int[] tab1, ref int[] tab2)
    {
        var negatives = new List<int>();
        var positives = new List<int>();
        
        foreach (var item in tab1.Concat(tab2))
            if (item < 0)
                negatives.Add(item);
            else
                positives.Add(item);
    
        tab1 = positives.ToArray();
        tab2 = negatives.ToArray();
    }
