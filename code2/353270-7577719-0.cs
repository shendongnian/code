    public class MainObject
    {
        public string name { get;set; }
        // rest of the names as properties
        public List<SetObject> @set { get;set; }
    }
    public class SetObject
    {
        public string setcode { get;set; }
        // rest of your sets names as properties
    }
