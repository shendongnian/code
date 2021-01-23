    public class Renderer
    {
        public string uuid { get; set; }
        public string ipAddress { get; set; }
        public string name { get; set; }
        public string profileId { get; set; }
        public string status { get; set; }
    }
    
    public class RootObject
    {
        public string serverStatus { get; set; }
        public Renderer[] renderers { get; set; }
    }
