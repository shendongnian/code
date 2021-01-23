    //Page load starts here
    var json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(new
    {
        api_key = "my key",
        action = "categories",
        store_id = "my store"
    });
    var json2 = "{\"api_key\":\"my key\",\"action\":\"categories\",\"store_id\":\"my store\",\"user\" : {\"id\" : 12345,\"screen_name\" : \"twitpicuser\"}}";
    var list = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FooBar>(json);
    var list2 = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<FooBar>(json2);
    string a = list2.action;
    var b = list2.user;
    string c = b.screen_name;
    //Page load ends here
    public class FooBar
    {
        public string api_key { get; set; }
        public string action { get; set; }
        public string store_id { get; set; }
        public User user { get; set; }
    }
    public class User
    {
        public int id { get; set; }
        public string screen_name { get; set; }
    }
