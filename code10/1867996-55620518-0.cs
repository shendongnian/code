        private static void Clear(this DbContext context)
        {
            var properties = context.GetType().GetProperties();
            foreach (var property in properties)
            {
                var setType = property.PropertyType;
                bool isDbSet = setType.IsGenericType && (typeof(DbSet<>).IsAssignableFrom(setType.GetGenericTypeDefinition()));
                if (!isDbSet) continue;
                dynamic dbSet = property.GetValue(context, null);
                dbSet.RemoveRange(dbSet);
            }
            context.SaveChanges();
        }
