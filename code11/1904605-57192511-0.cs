    static void WriteDictionaryToFile<TKey, TValue>( IDictionary<TKey, TValue> dict, string filename )
    {
      using (var fs = new StreamWriter( new FileStream(filename, FileMode.Append, FileAccess.Write ) ) )
      {
        foreach (var kvp in dict)
        {
          fs.WriteLine(string.Format("{0}|{1}", kvp.Key, kvp.Value));
        }
      } 
    }
