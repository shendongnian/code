    public class License
    {
        public string Name { get; set; }
        public string Frn { get; set; }
        public string Callsign { get; set; }
        public string CategoryDesc { get; set; }
        public string ServiceDesc { get; set; }
        public string StatusDesc { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Id { get; set; }
        public string DetailUrl { get; set; }
    }
    public class Licenses
    {
        public License[] License { get; set; }
    }
    public class FCC
    {
        public string status { get; set; }
        public Licenses Licenses { get; set; }
    }
