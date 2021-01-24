public class collection
    {
        public passages passages { get; set; }
        public String answers { get; set; }
        public String query_id { get; set; }
    }
should be 
public class collection
    {
        public List<passages> passages { get; set; }
        public String answers { get; set; }
        public String query_id { get; set; }
    }
note the List<passages> in the latter.
