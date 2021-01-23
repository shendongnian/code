    string[] thestrings = source.Split(',');
    string lastItem = thestrings.FirstOrDefault();
    List<string> keepers = new List<string>();
    
    foreach(string item in thestrings)
    {
      if (item == "P")
      {
        if (lastItem != "P")
        {
          keepers.Add(lastItem);
        }
        keepers.Add(item);
      }
      lastItem = item;
    }
