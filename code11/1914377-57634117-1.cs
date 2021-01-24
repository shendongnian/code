    public static IEnumerable<int> DoStuff(IEnumerable<int> source, int target)
    {
       var sum = 0;
       foreach (var item in source)
          if (item == target)
             sum += item; 
          else if (sum > 0)
          {
             yield return sum;
             sum = 0;
          }
       if (sum > 0) 
          yield return sum;
    }
