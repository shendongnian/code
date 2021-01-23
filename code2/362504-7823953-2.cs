    public class item
    {
      public int id { get; set; }
      public string name { get; set; }
    }
    
    string json = "[{\"item\" : { \"id\":1 , \"name\":\"abc\" }} , {\"item\" : { \"id\":1 , \"name\":\"abc\"}}]";
    
    List<item> items = JsonConvert.DeserializeObject<List<item>>(json);
