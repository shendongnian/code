    public void FoldStrings(List<List<string>> stringCollections)
    {
       var interned = new Dictionary<string,string> ();
       foreach (var stringCollection in stringCollections)
       {
          for (int i = 0; i < stringCollection.Count; i++)
          {
             string str = stringCollection[i];
             string s;
             if (interned.TryGetValue (str, out s))
             {
                // We already have an instance of this string.
                stringCollection[i] = s;
             }
             else
             {
                // First time we've seen this string... add to hashtable.
                interned[str]=str;
             }
          }
       }
    }
