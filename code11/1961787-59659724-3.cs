    public class User
    {
        public string email { get; set; }
        public string libraryId { get; set; }
        public string name { get; set; }
        public DateTime joiningDate { get; set; }
        public string zone { get; set; }
        public Dictionary<DateTime, int> rentals {get;set;}
    }
