    public class Arch
    {
        public string id { get; set; }
    }
    
    public class Nail
    {
        public string name { get; set; }
    }
    
    public class RootObject
    {
        public Arch arch { get; set; }
        public List<Nail> nails { get; set; }
        public string token { get; set; }
    }
