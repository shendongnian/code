    public static IList SumValues(int value, int times)
    {
       List<int> sums = new List<int>();
       for (int i = 0; i < times; i++)
       {
           sums.Add(i*value);
       }
       return sums;
    }
