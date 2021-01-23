    WebClient client = new WebClient();
    string csvContents = client.DownloadString(UrlAsString);
    string[] csvLines = csvContents.Split(new string[] {"\n", "\r\n"},
                                          StringSplitOptions.RemoveEmptyEntries); 
    SomeModel model = new SomeModel()
    model.KeyValuePairs = csvLines.Select(x => x.Contains(","))
                              .Select(x => new KeyValuePair(x.Split(",")[0],
                                                            x.Split(",")[1]);
    public class SomeModel()
    {
      public IEnumerable<KeyValuePair> KeyValuePairs { get; set; }
    }
    public class KeyValuePair()
    {
       public KeyValuePair() { }
       public KeyValuePair(string Key, string Value) 
       { 
         this.Key = Key;
         this.Value = Value;
       }
       public string Key { get; set; }
       public string Value { get; set; }
    }
