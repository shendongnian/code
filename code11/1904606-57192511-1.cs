    static void WriteDictionaryToFileEasy<TKey, TValue>( IDictionary<TKey, TValue> dict, string filename)
    {
      using (var fs = File.AppendText( filename ))
      {
        foreach (var kvp in dict)
        {
          fs.WriteLine(string.Format("{0}|{1}", kvp.Key, kvp.Value));
        }
      }
    }
