    static void WriteDictionaryToFileLinq<TKey, TValue>( IDictionary<TKey, TValue> dict, string filename)
    {
      if ( dict == null || dict.Count == 0)
      {
        return;
      }
      File.AppendAllText(
        filename, 
        string.Join(
          Environment.NewLine, 
          dict.Select( kvp => string.Format("{0}|{1}", kvp.Key, kvp.Value) )
            .Concat( new[] { string.Empty } ).ToArray() 
        )  
      );
    }
