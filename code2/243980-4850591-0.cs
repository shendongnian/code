    public class DefaultSchemaConvention : IConfigurationConvention<Type, EntityTypeConfiguration> {
      string defaultSchema;
      public DefaultSchemaConvention(string defaultSchema) {
        if (String.IsNullOrWhiteSpace(defaultSchema))
          throw new ArgumentException("defaultSchema");
        this.defaultSchema = defaultSchema;
      }
      void IConfigurationConvention<Type, EntityTypeConfiguration>.Apply(Type memberInfo, Func<EntityTypeConfiguration> configuration) {
        EntityTypeConfiguration cfg = configuration();
        string tableName = cfg.EntitySetName;
        if (String.IsNullOrEmpty(tableName))
          tableName = memberInfo.Name;
        cfg.ToTable(tableName, this.defaultSchema);
      }
    }  
