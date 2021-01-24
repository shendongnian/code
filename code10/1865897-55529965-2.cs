    public class Abstract
    {
        public string UpdatedBy { get; set; }
        public string UpdatedAt { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        foreach (var property in typeof(Product).GetProperties())
        {
            builder.Entity<Abstract>()
                    .ToTable("Products_Abstract")
                    .Property(property.PropertyType, property.Name);
        }
    }
