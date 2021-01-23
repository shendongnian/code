    namespace System.Data.Entity.ModelConfiguration.Conventions
    {
      /// <summary>
     /// Convention to convert any data types that were explicitly specified, via data     annotations or <see cref="T:System.Data.Entity.DbModelBuilder"/> API,
     ///                 to be lower case. The default SqlClient provider is case   sensitive and requires data types to be lower case. This convention 
    ///                 allows the <see   cref="T:System.ComponentModel.DataAnnotations.ColumnAttrbiute"/> and <see cref="T:System.Data.Entity.DbModelBuilder"/> API to be case insensitive.
    /// 
    /// </summary>
    public sealed class ColumnTypeCasingConvention : IDbConvention<DbTableColumnMetadata>,   IConvention
    {
      internal ColumnTypeCasingConvention()
    {
    }
    [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
    void IDbConvention<DbTableColumnMetadata>.Apply(DbTableColumnMetadata tableColumn, DbDatabaseMetadata database)
    {
      if (string.IsNullOrWhiteSpace(tableColumn.TypeName))
        return;
      tableColumn.TypeName = tableColumn.TypeName.ToLowerInvariant();
    }
