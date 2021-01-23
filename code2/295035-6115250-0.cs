    using VBCollection = Microsoft.VisualBasic.Collection;
    ...
    public static VBCollection ToVBCollection(this Hashtable table) {
      var collection = new VBCollection();
      foreach (var pair in table) {
        // Note: The Add method in collection takes value then key.
        collection.Add(pair.Value, pair.Key);  
      }
      return collection;
    }
