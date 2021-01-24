    public class SecurityLogOfficer
    {
        public int SecurityLogID { get; set; }
        public SecurityLog SecurityLog { get; set; }
        public int OfficerID { get; set; }
        public Officer Officer { get; set; }
    }
    public class Officer
    {
        public int ID { get; set; }
        //other properties
        public List<SecurityLogOfficer> SecurityLogOfficers { get; set; }
    }
    public class SecurityLog
    {
        public int ID { get; set; }
        //other properties
        public virtual List<SecurityLogOfficer> SecurityLogOfficers { get; set; }
    }
