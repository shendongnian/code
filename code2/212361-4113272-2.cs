    int[] source = new int[] { 1, 2, 3, 4, 4, 4, 5, 6, 7, 4, 4, 4, 8, 9, 4, 4, 4 };
    
    List<int> result = new List<int>();
    result.Add(
        source.Aggregate((acc, c) =>
        {
            if (acc != c)
                result.Add(acc);
            return c;
        })
    );
