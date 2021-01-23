    foreach (var kvp1 in masterDictMethod())
    {
       Console.WriteLine("Key = {0}, Inner Dict:\n", kvp1.Key);
       foreach (var kvp2 in kvp1.Value)
       {
          Console.WriteLine("Date = {0}, Double = {1}", kvp2.Key, kvp2.Value);
       }
    }
