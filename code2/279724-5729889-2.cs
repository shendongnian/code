    IList<string> stringList = new List<string>() { "red", "red", 
                                                    "blue", "green", 
                                                    "green", "red", 
                                                    "red", "yellow", 
                                                    "white", "white", 
                                                    "red", "white", "white" };      
      for (int i = 0; i < stringList.Count; i++)
      {
        // select the first element
        string first = stringList[i];
        // select the next element if it exists
        if ((i + 1) == stringList.Count) break;
        string second = stringList[(i + 1)];
        // remove the second one if they're equal
        if (first.Equals(second))
        {
          stringList.RemoveAt((i + 1));
          i--;
        }
      }
