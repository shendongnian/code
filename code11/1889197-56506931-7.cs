        public class EffectiveParams
        {
          public string data_set { get; set; }
          public List<string> base_currencies { get; set; }
          public List<string> quote_currencies { get; set; }
        }
    
        public class Meta
        {
          public EffectiveParams effective_params { get; set; }
          public string endpoint { get; set; }
          public DateTime request_time { get; set; }
          public List<object> skipped_currency_pairs { get; set; }
        }
    
        public class Quote
        {
          public string base_currency { get; set; }
          public string quote_currency { get; set; }
          public string bid { get; set; }
          public string ask { get; set; }
          public string midpoint { get; set; }
        }
    
        public class RootObject
        {
          public Meta meta { get; set; }
          public List<Quote> quotes { get; set; }
        }
