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
    public class Properties
    {
        public Firstname firstname { get; set; }
        public Lastmodifieddate lastmodifieddate { get; set; }
        public Company company { get; set; }
        public Lastname lastname { get; set; }
    }
    public class UserForDeserialize
    {
        public int vid { get; set; }
        public Properties properties { get; set; }
    }
