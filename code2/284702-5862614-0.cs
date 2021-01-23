A lot of times, using out can help by giving you a slight performance gain.
Consider the TryGetValue method on IDictionary (say myDictionary is an IDictionary&lt;string, string&gt;) Rather than doing this:
    string value = String.Empty;
    if (myDictionary.ContainsKey("foo"))
    {
      value = myDictionary["foo"];
    }
Both ContainsKey and the indexer need to look up the key in the dictionary, but you can avoid this double-lookup on the positive case by going:
    string value;
    if (!myDictionary.TryGetValue("foo", out value))
    {
      value = String.Empty;
    }
IMO, that's a decent reason for using out parameters.
