    public class WikiSearchQuery
    {
      [JsonProperty("pages")]
      public Dictionary<object, WikiSearchPage> Pages { get; set; }
    }
    public class WikiSearchPage
    {
      [JsonProperty("pageid")]
      public int Pageid { get; set; }
      [JsonProperty("title")]
      public string Title { get; set; }
    }
    public class WikiSearchResults
    {
      [JsonProperty("query")]
      public WikiSearchQuery Query { get; set; }
    }
