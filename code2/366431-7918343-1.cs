    public class DocumentType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
    public class DocumentTypeMap : ClassMap<DocumentType>
    {
        public DocumentTypeMap()
        {
            GenerateMap();
        }
        void GenerateMap()
        {
            Schema("Core");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Name).Length(128).Not.Nullable();
            DiscriminateSubClassesOnColumn("Type");
        }
    }
