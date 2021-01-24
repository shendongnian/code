    Dictionary<int, IEnumerable<SomeObject>> myDictionary = setDictionary(); //Assume that this method populate the dictionary.
    IEnumerable<int> keys = myDictionary.Keys;
    foreach (int key in keys)
    {
      var templist = myDictionary[key].ToList();
      templist.AddRange(getListOfSomeObject());
      myDictionary[key] = templist;
    
    }
