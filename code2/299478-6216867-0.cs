    dictionary.WithIndex().ForEach(
      (item) =>
      {
        var kvp = item.Value; // This extracts the KeyValuePair
        if (item.IsLast)
        {
          Console.WriteLine("Key=" + kvp.Key.ToString() + "; Value=" + kvp.Value.ToString());
        }
      });
