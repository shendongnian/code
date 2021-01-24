    public class Root
    {
        public long addedAt { get; set; }
        public int vid { get; set; }
        public int canonicalvid { get; set; }
        public object[] mergedvids { get; set; }
        public int portalid { get; set; }
        public bool iscontact { get; set; }
        public string profiletoken { get; set; }
        public string profileurl { get; set; }
        public Properties properties { get; set; }
    }
    public class Properties
    {
        public Firstname firstname { get; set; }
        public Lastmodifieddate lastmodifieddate { get; set; }
        public Company company { get; set; }
        public Lastname lastname { get; set; }
    }
    public class Firstname
    {
        public string value { get; set; }
    }
    public class Lastmodifieddate
    {
        public string value { get; set; }
    }
    public class Company
    {
        public string value { get; set; }
    }
    public class Lastname
    {
        public string value { get; set; }
    }
