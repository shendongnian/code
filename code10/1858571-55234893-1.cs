    public class TvRequests
    {
        public string Title { get; set; }
        public OmbiUser RequestedUser { get; set; }
        
        public DateTime Date { get; set; }
    }
    public class OmbiUser
    {
        public string Username;
        public DateTime Date { get; set; }
    }
