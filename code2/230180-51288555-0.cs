       Dictionary<string, string> myDictionary = new Dictionary<string, string>();
          myDictionary.Add("a", "x");
          myDictionary.Add("b", "y");
          int i = Array.IndexOf(myDictionary.Keys.ToArray(), "a");
          int j = Array.IndexOf(myDictionary.Keys.ToArray(), "b");
