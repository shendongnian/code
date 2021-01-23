    public static int Sum(IEnumerable listOfInts)
    {
        int total = 0;
        foreach (object obj in listOfInts)
        {
            if (obj is int)
                total += (int)obj;
        }
        return total;
    }
