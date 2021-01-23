     // The required size is the count of the biggest list
    var sizeRequired = MyDict.Values.Max(l => l.Count);
    // Each string key should map to a key in the new dictionary
    // Each List<string> value should map to a new list, padded as necessary.
    var paddedDict = MyDict.ToDictionary
      (
         kvp => kvp.Key,
         kvp => kvp.Value
                   .Concat(Enumerable.Repeat(string.Empty, sizeRequired - kvp.Value.Count))
                   .ToList()
      );
