    public class EntityMap : ClassMap<Entity>
    {
        public EntityMap()
        {
            Table("Entities");
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.Name).CustomSqlType("NVARCHAR").Length(50).Not.Nullable();
            HasMany<Property>(x => x.Properties)
                .Table("Properties")
                .KeyColumn("PropertyName")
                .Inverse()
                .AsBag();
        }
    }
    public class PropertyMap : ClassMap<Property>
    {
        public PropertyMap()
        {
            Table("Properties");
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.PropertyName).Length(50).Not.Nullable();
            Map(x => x.IntValue);
            Map(x => x.DecimalValue);
        }
    }
