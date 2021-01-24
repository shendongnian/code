    public static char MostAparitionsChar(string word)
     {
     char result = ' ';
     int max = int.MinValue;
     foreach(var grouping in word.GroupBy(x => x))
      {
      int count = grouping.Count();
      if(count > max)
       {
       max = count;
       result = grouping.Key;
      }
     }
     return result;
    }
