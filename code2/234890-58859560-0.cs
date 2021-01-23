    public class MyContext : DbContext
    {
        public DbSet<Foo> Foos { get; set; }
    
        public MyContext()
        {
            ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized +=
                (sender, e) => SetDateTimesToUtc(e.Entity);
        }
        private static void SetDateTimesToUtc(object entity)
        {
            if (entity == null)
            {
                return;
            }
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(entity, DateTime.SpecifyKind((DateTime)property.GetValue(entity), DateTimeKind.Utc));
                }
                else if (property.PropertyType == typeof(DateTime?))
                {
                    var value = (DateTime?)property.GetValue(entity);
                    if (value.HasValue)
                    {
                        property.SetValue(entity, DateTime.SpecifyKind(value.Value, DateTimeKind.Utc));
                    }
                }
            }
        }
    }
