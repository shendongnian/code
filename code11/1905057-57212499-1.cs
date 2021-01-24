    public class DataClass
    {
    	public Details details { get; set; } // Since you are only interested in Status
    }
    public class Details
    {
        public string status { get; set; }
        public Dictionary<string,string> status_list { get; set; } 
    }
    
