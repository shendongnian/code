    public static class ModelConverterToTVP
    {
    public static SqlMapper.ICustomQueryParameter AsTableValuedParameter<T> (this IEnumerable<T> enumerable, string typeName)
        {
            var dataTable = new DataTable(typeName);
            ...
        }
    }
