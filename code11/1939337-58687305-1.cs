    public partial class JsonModel
    {
        [JsonProperty("patient")]
        public Patient Patient { get; set; }
    }
    
    public partial class Patient
    {
    
        [JsonProperty("Number")]
        public string Number;
    
        [JsonProperty("FirstName")]
        public string FirstName;
    
        [JsonProperty("LastName")]
        public string LastName;
    
        [JsonProperty("BirthDate")]
        public DateTime BirthDate;
    
        [JsonProperty("Phone")]
        public string Phone;
    
        [JsonProperty("Mobile")]
        public string Mobile;
    
        [JsonProperty("Address")]
        public string Address;
    
        [JsonProperty("Job")]
        public string Job;
    
        [JsonProperty("Note")]
        public string Note;
    
        [JsonProperty("GenderId")]
        public int GenderId;
    
        // Return a textual representation of the order.
        public override string ToString()
        {
            return "FirstName: " + FirstName +
            "\nLastName: " + LastName +
             "\nBirthDate: " + BirthDate;
        }
    }
    
       
    
