    public class Request
    {
        //Other properties
        ..
        public int ResidentID { get; set;}
        ForeignKey["ResidentID"]
        public Resident Resident { get; set;}   
    }
