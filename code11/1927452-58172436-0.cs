    class Entity
    {
        public List<int> List { get; set; }
        public Entity(List<int> list)
        {
            List = list;
        }
        public Entity(Entity original)
        {
            string originalJson = JsonConvert.SerializeObject(original);
            JsonConvert.PopulateObject(originalJson, this);
        }
    }
