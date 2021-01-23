    Dictionary<string, string[]> source = GetDictionary();
    
    targetSize = source.Values.Select(x => x.Length).Max();
    
    Dictionary<string, string[]> result = source.ToDictionary(
      kvp => kvp.Key,
      kvp => kvp.Value != null ?
        kvp.Value.Concat(Enumerable.Repeat("", targetSize - kvp.Value.Length)).ToArray() :
        Enumerable.Repeat("", targetSize).ToArray
    );
