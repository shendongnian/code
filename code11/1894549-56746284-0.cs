        public class YourSettings
        {
            public string Root { get; set; }
            public string Log { get; set; }
            public string Data { get; set; }
            public string LogPath => Log.Replace("{Root}", Root);
            public string DataPath => Data.Replace("{Root}", Root);
        }
