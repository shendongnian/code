    class Metrics
    {
       public DateTime start = DateTme.MinValue;
       public DateTime end = DateTme.MinValue;
       [JsonProperty("requests/duration")]
       public RequestsDuration requestsduration = null;
    }
