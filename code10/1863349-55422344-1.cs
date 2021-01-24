    static List<int> GetRangeOfNumbers(int start, int end)
    {
        var list = new List<int>();
        for(var x = start; x <= end; x++)
        {
            list.Add(x);
        }
        return list;
    }
