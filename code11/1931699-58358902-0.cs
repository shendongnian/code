    public class Configuration
        {
            public bool Debug { get; set; }
            public string Log { get; set; }
            public Project[] Projects { get; set; }
        }
    
        public class Project
        {
            public string Name { get; set; }
            public bool ShowInfo { get; set; }
            public int[][] Ranges { get; set; }
            public Additional[] Additional { get; set; }
        }
    
        public class Additional
        {
            public string Name { get; set; }
            public string Parameter { get; set; }
        }`
