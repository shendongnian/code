    public class DetailComplaint
    {
        public decimal Id {get; set; }
        public decimal Status {get; set; }
        public string Name {get; set; }
        public decimal ServiceId {get; set; }
        public string Service {get; set; }
        public string Title {get; set; }
        public string Customer {get; set; }
        public string Description {get; set; }
        public DateTime CreatedDate {get; set; }
        public decimal CreatedBy {get; set; }
        public string Author {get; set; }
        public decimal? AssignedBy {get; set; }
        public decimal? AssignedTo {get; set; }
        public string Technician {get; set; }
        public DateTime? AssignedDate {get; set; }
        public string Contact {get; set; }
    }
