    public class MainNews
    {
        public List<NewAlert> newsalert { get; set; }
    }
    
    public class NewAlert
    {
        public Dictionary<int, NewItem> newslist { get; set; }
    }
    
    public class NewItem
    {
        public string newsid { get; set; }
        public string headline { get; set; }
        public string newscode { get; set; }
        public string newstime { get; set; }
    }
