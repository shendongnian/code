    public class Route
    {
        public string status_message { get; set; }
        public string route_geometry { get; set; }
        public int status { get; set; }
        public List<List<object>> route_instructions { get; set; }
        public List<string> route_name { get; set; }
        public RouteSummary route_summary { get; set; }
        public string viaRoute { get; set; }
        public string subtitle { get; set; }
        public Phyroute phyroute { get; set; }
    }
    public class RouteSummary
    {
        public string start_point { get; set; }
        public string end_point { get; set; }
        public int total_time { get; set; }
        public int total_distance { get; set; }
    }
    
    public class Phyroute
    {
        public string status_message { get; set; }
        public string route_geometry { get; set; }
        public int status { get; set; }
        public List<List<object>> route_instructions { get; set; }
        public List<string> route_name { get; set; }
        public RouteSummary route_summary { get; set; }
        public string viaRoute { get; set; }
        public string subtitle { get; set; }
    }
    
