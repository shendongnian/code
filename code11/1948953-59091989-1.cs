    public class NewOrderModel
    {
       private readonly List<KeyValuePair<string, string>> symbols = new List<KeyValuePair<string, string>>
       {
          new KeyValuePair<string, string> ("WINZ19", "XBMF"),
          new KeyValuePair<string, string> ("WDOZ19", "XBMF")
       };
      private string _symbol;
    
      [Required]
      public string Symbol
       {
          get => _symbol;
    
          set
           {
              Market = this.symbols.Find(findSymbol => findSymbol.Key == value).Value;
              _symbol = value;
            }
        }
 
        private string _market;   
        public string Market
            {
                get => _market;
    
                private set
                {
                    _market = value;
                }
            }
