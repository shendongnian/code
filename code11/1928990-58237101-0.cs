    var json = // your json string
    var root = JsonConvert.DeserializeObject<RootObject>(json);
    var response = root.Response;
    // classes below
    public class Permissions
    {
        public bool isGameAdmin { get; set; }
        public bool showDetailedOnWebMaps { get; set; }
    }
    
    public class Vtc
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tag { get; set; }
        public bool inVTC { get; set; }
        public int memberID { get; set; }
    }
    
    public class Response
    {
        public int id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string smallAvatar { get; set; }
        public string joinDate { get; set; }
        public long steamID64 { get; set; }
        public string steamID { get; set; }
        public string groupName { get; set; }
        public int groupID { get; set; }
        public bool banned { get; set; }
        public object bannedUntil { get; set; }
        public bool displayBans { get; set; }
        public Permissions permissions { get; set; }
        public Vtc vtc { get; set; }
    }
    
    public class RootObject
    {
        public bool error { get; set; }
        public Response response { get; set; }
    }
