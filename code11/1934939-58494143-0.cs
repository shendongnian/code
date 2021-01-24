    public static IList SumValues(int value, int times)
    {
       List<int> sums = new List<int>();
       for (int i = 0; i < times; i++)
       {
           while (i < times)
           sums.Add(value*4);
       }
       return sums;
    }
