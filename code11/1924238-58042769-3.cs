cs
    public class MyEntity: Entity
    {
        public int Id { get; private set; }
        private readonly List<RelatedEntity> _relatedEntities = _collection.ToList().AsReadOnly();
        public IEnumerable<RelatedEntity> RelatedEntities => _relatedEntities;
    }
Update your fluent API as follows:
cs
    builder.HasKey(x=>x.Id);
    builder.Metadata.FindNavigation("RelatedEntities")
        .UsePropertyAccessMode(PropertyAccessMode.Field);
