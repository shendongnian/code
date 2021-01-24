    public class C1
    {
        public string name { get; set; }
        public string type { get; set; }
    }
    
    public class C2
    {
        public string name { get; set; }
        public string type { get; set; }
    }
    
    public class ReportHeader
    {
        public C1 c1 { get; set; }
        public C2 c2 { get; set; }
    }
    
    public class Datum
    {
        public ReportHeader report_header { get; set; }
        public List<Dictionary<string, string>> report_row { get; set; }
    }
    
    public class RootObject
    {
        public List<Datum> data { get; set; }
        public List<string> message { get; set; }
        public int status { get; set; }
    }
