    public interface ia
    {
        string x1 { get; set; }
        string x2 { get; set; }
        string x3 { get; set; }
    }
    public class a : ia
    {
        public string x1 { get; set; }
        public string x2 { get; set; }
        public string x3 { get; set; }
    }
    public class b : a, ia
    {
    }
