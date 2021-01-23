    public class StatusViewModel
    {
        public string Label1 { get; set; }
        public string Label2  { get; set; }
        public IDictionary<string, string> ListBox { get; set; }
    }
    
    [WebMethod()]
    public static StatusViewModel  GetStatus()
    {
        // do work
        return new StatusViewMode....
    
    }
