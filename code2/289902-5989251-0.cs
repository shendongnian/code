    string input = "abc:1|bbbb:2|xyz:45|p:120";
    string pattern = @"(?<Key>[^:]+)(?:\:)(?<Value>[^|]+)(?:\|?)";
     
    Dictionary<string, string> KVPs
        = ( from Match m in Regex.Matches( input, pattern )
          select new
          {
              key = m.Groups["Key"].Value,
              value = m.Groups["Value"].Value
           }
           ).ToDictionary( p => p.key, p => p.value );
     
    foreach ( KeyValuePair<string, string> kvp in KVPs )
        Console.WriteLine( "{0,6} : {1,3}", kvp.Key, kvp.Value );
     
    /* Outputs:
     abc :   1
    bbbb :   2
     xyz :  45
      p  : 120
     */
