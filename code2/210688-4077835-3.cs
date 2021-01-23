    public void IEnumerale<string> GenerateStrings()
    {
      int index = 0;
      // generate "infinit" number of values ...
      while (true)
      {
         // ignoring index == int.MaxValue
         yield return GetString(index++);
      }
    }
    List<string> strings = GenerateStrings().Take(1000).ToList()
