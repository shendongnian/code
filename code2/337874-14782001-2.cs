    public class City_Map : SchemaNameEntityTypeConfiguration<City>
    {
        public City_Map(string schemaName)
            : base(schemaName)
        {
            ToTable("City");
            HasKey(t => t.Code);
            Property(t => t.Code)
                .HasColumnType("integer")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.CityName)
                .HasColumnName("City")
                .HasMaxLength(50);
            Property(t => t.State)
                .HasMaxLength(2);
        }
    }
