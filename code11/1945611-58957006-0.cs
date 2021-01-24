    public class MyDbContext : DbContext
    {    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
    
            foreach(var entity in builder.Model.GetEntityTypes())
            {           
                foreach(var property in entity.GetProperties())
                {
                    property.Relational().ColumnName = property.Relational().ColumnName.Replace("_", String.Empty);
                }
            }
        }
    }
