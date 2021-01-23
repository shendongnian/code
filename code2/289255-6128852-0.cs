    public static class EntityObjectExtensions
    {
        public static bool IsDeleted(this EntityObject obj)
        {
            return obj.EntityState == System.Data.EntityState.Deleted;
        }
    
        public static bool Delete(this EntityObject obj)
        {
            Context.DeleteObject(obj);
        }
    
        public static bool IsInserted(this EntityObject obj)
        {
            return obj.EntityState == System.Data.EntityState.Added;
        }
    
        public static bool Insert(this EntityObject obj)
        {
            Context.AddObject(obj.GetType().Name, obj);
        }
    }
