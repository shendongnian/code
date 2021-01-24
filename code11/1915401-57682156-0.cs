    public class ResponseBaseClass
    {
        public IEnumerable<TeamStatsClass> teams { get; set; }
        public string copyright { get; set; }
    }
    public class TeamStatsClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public Division division { get; set; }
    }
    public class Division
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameShort { get; set; }
        public string link { get; set; }
    
    }
