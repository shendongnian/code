    public int RandomPos(int max) {
      int i = r.Next(max);
      var intList = numberList.Select(y => int.Parse(y)).ToList();
      while(numberList.Contains(i))
      {
         i = r.Next(max);
      }
      return i;
    }
