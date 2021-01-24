    public class Incident
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReportedBy { get; set; }
        public int SiteId { get; set; }
        public Site Site{ get; set; }
    }
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Incident Incident { get; set; }
    }
