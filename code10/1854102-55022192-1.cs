    public partial class Tickers
    {
        [JsonProperty("base")]
        public string Base { get; set; }
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }
        [JsonProperty("rates")]
        public Rates Rates { get; set; }
    }
    public partial class Rates
    {
        [JsonProperty("NZD")]
        public double Nzd { get; set; }
        [JsonProperty("EUR")]
        public double Eur { get; set; }
    }
