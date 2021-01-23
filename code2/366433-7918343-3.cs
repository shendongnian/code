    public class FileConversion
    {
        public virtual int Id { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
    public class FileConversionMap : ClassMap<FileConversion>
    {
        public FileConversionMap()
        {
            GenerateMap();
        }
        void GenerateMap()
        {
            Schema("Core");
            Id(x => x.Id).GeneratedBy.Identity();
            References(x => x.DocumentType).Not.Nullable().Fetch.Select();
        }
    }
