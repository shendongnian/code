    public static class EntityExtensions
    {
        public static RootObject ToJsonWrapper(this Entity entity)
        {
            if (entity == null)
                return null;
            var root = new RootObject();
            root.ID = entity.Id;
            // etc ...
        }
    }
