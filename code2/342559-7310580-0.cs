    public IEnumerable<string> Appender(IEnumerable<string> strings)
    {
      List<string> myList = new List<string>();
      foreach(string str in strings)
      {
          myList.Add(str + "roxxors");
      }
      return myList;
    }
