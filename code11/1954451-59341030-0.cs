    using (StreamWriter writer = new StreamWriter(fs))
    {
       // Write pairs.
       foreach (var pair in dictionary)
       {
           writer.WriteLine("[{0} {1}]", pair.Key, pair.Value); 
       }
    }
