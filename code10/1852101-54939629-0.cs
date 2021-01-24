    public class Job 
    {
        public string Company { get; set; }
        public string Position { get; set; }
        public Dictionary<string,object> job { get; set; }
    
        public Job()
        {
            job = new Dictionary<string, object>();
        }
    }
