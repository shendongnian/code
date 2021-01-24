    public class RootObject
    {
        public string endpoint { get; set; }
        public int id { get; set; }
        public List<string> identifiers { get; set; }
        public string name { get; set; }
        public int ping { get; set; }
    
        public override string ToString()
        {
            return name;
        }
    }
