    public class SecurityLog
    {
        public int SecurityLogId { get; set; }
        public string Name { get; set; }
        public IList<SecurityLogOfficers> SecurityLogOfficers { get; set; }
    }
    public class Officer
    {
        public int OfficerId { get; set; }
        public string Active { get; set; }
        public string FullName { get; set; }
        public IList<SecurityLogOfficers> SecurityLogOfficers { get; set; }
    }
    public class SecurityLogOfficers
    {
        public int OfficerId { get; set; }
        public Officer Officer { get; set; }
        public int SecurityLogId { get; set; }
        public SecurityLog SecurityLog { get; set; }
    }
