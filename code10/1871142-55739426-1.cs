    public class Rootobject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int MemberID { get; set; }
        public Detail[] Details { get; set; }
    }
    public class Detail
    {
        public string Plan { get; set; }
        public string Product { get; set; }
        public DateTime ProductStartDate { get; set; }
        public DateTime ProductEndDate { get; set; }
        public string Flag { get; set; }
    }
