    public abstract class SchemaNameEntityTypeConfiguration<TEntityType> : EntityTypeConfiguration<TEntityType> where TEntityType : class
    {
        public string SchemaName { get; set; }
        public SchemaNameEntityTypeConfiguration(string schemaName)
            : base()
        {
            this.SchemaName = schemaName;
        }
        public new void ToTable(string tableName)
        {
            base.ToTable(tableName, SchemaName);
        }
    }
