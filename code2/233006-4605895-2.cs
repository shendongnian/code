    public int RandomPos(int max) {
      int i = r.Next(max);
      var intList = numberList.Split(',').ToDictionary<string,int>((n) => int.Parse(n));
      while(intList.Contains(i))
      {
         i = r.Next(max);
      }
      return i;
    }
