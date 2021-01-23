    public static IEnumerable<string> GetColumnNames<TEntity>(Table<TEntity> table)
        where TEntity : class
    {
        return new System.Data.Linq.Mapping.AttributeMappingSource()
            .GetModel(table.Context.GetType())
            .GetTable(typeof(TEntity))
            .RowType
            .DataMembers
            .Where(dm => !dm.IsAssociation)
            .Select(dm => dm.MappedName);
    }
    public static IEnumerable<string> GetColumnNamesMeta(DataContext context, string functionName)
    {
        var type = context.GetType();
        return new System.Data.Linq.Mapping.AttributeMappingSource()
            .GetModel(type)
            .GetFunction(type.GetMethod(functionName))
            .ResultRowTypes
            .SelectMany(rrt => rrt.DataMembers
                                  .Where(dm => !dm.IsAssociation)
                                  .Select(dm => dm.MappedName));
    }
