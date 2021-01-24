        public class Counter
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public string Name { get; set; }
            public long Version { get; set; }
            public DateTime Ddate { get; set; }
        }
