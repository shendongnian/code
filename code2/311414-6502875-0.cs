    public static class EntityDataSourceExtensions
    {
        public static TEntity GetEntityAs<TEntity>(this object dataItem) where TEntity : class
        {
            var entity = dataItem as TEntity;
            if (entity != null)
                return entity;
            var td = dataItem as ICustomTypeDescriptor;
            if (td != null)
                return (TEntity)td.GetPropertyOwner(null);
            return null;
        }
        public static Object GetEntity(this object dataItem)
        {
            var td = dataItem as ICustomTypeDescriptor;
            if (td != null)
                return td.GetPropertyOwner(null);
            return null;
        }
    }
