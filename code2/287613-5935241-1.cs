        public class Channel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string SortKey { get; set; }
            public string SourceId { get; set; }            
        }
        public class MainItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Icon { get; set; }
            public List<Channel> Channels { get; set; }
        }
