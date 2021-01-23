    public class RouteAttribute : Attribute
    {
        public RouteAttribute(string url, string query, string value) {
           this.url = url;
           this.dunno = new RouteValueDictionary(query, value);
        }
        // etc..
    }
    ...
    [Route("~/MyPage/Home.aspx", "query", "value")]
    public string HomePage
    {
      get { return "Home" }
    }
