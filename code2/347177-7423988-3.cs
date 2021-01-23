    // Get the shortest arraylist length (they should be equal this is just a paranoia check!) 
    // Replacement for min 
    int count = int.MaxValue;
    foreach (ArrayList a in myDicList.Values) if (a.Count < count) count = a.Count;
    // Get the collection of Keys 
    Dictionary<string, ArrayList>.KeyCollection keys = myDicList.Keys;
    // Perform the conversion 
    List<Dictionary<string, object>> result = new List<Dictionary<string, object>>(count);
    for (int i = 0; i < count; i++) {
      Dictionary<string, object> row = new Dictionary<string, object>(keys.Count);
      foreach (string key in keys) row.Add(key, myDicList[key][i]);
      result.Add(row);
    }
