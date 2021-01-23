    public static class DataExtensions
    {
        public static DbContext AddToContext<T>(this DbContext context, object entity, int count, int commitCount, bool recreateContext, Func<DbContext> contextCreator)
        {
            context.Set(typeof(T)).Add((T)entity);
    
            if (count % commitCount == 0)
            {
                context.SaveChanges();
                if (recreateContext)
                {
                    context.Dispose();
                    context = contextCreator.Invoke();
                    context.Configuration.AutoDetectChangesEnabled = false;
                }
            }
            return context;
        }
    }
