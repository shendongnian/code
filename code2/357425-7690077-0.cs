    var myDictionary = new Dictionary<string,string>();
    //populate Dictionary
    
    //a Dictionary<string,string> is an IEnumerable<KeyValuePair<sring,string>>
    //so, a little Linq magic will work wonders
    var myAttributeString = myDictionary.Aggregate(new StringBuilder(), (s, kvp) => s.Append(kvp.Key + "=\"" + (kvp.Value ?? String.Empty) + "\" "));
