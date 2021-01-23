    public class Level1
        {
            public Level1()
            {
                Id = ObjectId.GenerateNewId();
                NestedLevels = new List<LevelX>();
            }
            [BsonId]
            public Object Id { get; set; }
            public List<LevelX> NestedLevels { get; set; }
        }
        public class LevelX
        {
            public LevelX()
            {
                NestedLevels = new List<LevelX>();
            }
            public string Name { get; set; }
            public List<LevelX> NestedLevels { get; set; }
        }
