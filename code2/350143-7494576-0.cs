            [DataContract]
            private class DeserializationMain
            {
                [DataMember(Name = "result")]
                public string result; //works
                [DataMember(Name = "arguments")]
                public args arguments; //works, has deserialized activeTorrentCount
                [DataContract]
                public class args
                {
                    [DataMember(Name = "activeTorrentCount")]
                    public int activeTorrentCount;
    
                    [DataMember(Name = "cumulative-stats")]
                    public current cumulative_stats; //doesn't work, equals null
                    [DataContract]
                    public class current
                    {
                        [DataMember(Name = "downloadedBytes")]
                        public long downloadedBytes;
                    }
                }
            }
