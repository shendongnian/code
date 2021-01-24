`
foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
{
  foreach (Type type in assembly.GetTypes().Where(type => type.GetCustomAttribute<TableAttribute>() != null))
  {
    var tableAttribute = type.GetCustomAttribute<TableAttribute>();
    string tableName = tableAttribute.tableName; //whatever the field the of the tablename is
    foreach (var property in type.GetProperties().Where(property => property.GetCustomAttribute<ColumnAttribute>() != null))
    {
      var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
      var columnName = columnAttribute.columnName; //whatever the field the of the columnname is
    }
  }
}
`
