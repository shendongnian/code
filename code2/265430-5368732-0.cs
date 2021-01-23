    public static class EntityExtensions {
        public static void Save(this object entity) {
            var myMapper = MapperFactory.GetMapper();
            myMapper.persist(entity);
        }
        public static void Delete(this object entity) {
            //...
        }
    }
