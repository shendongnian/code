    public static IQueryable QueryItems(string param1, string param2, string param3)
    {
        var query = dataMap.tbl_ItemMap
            .Join(dataSet.Tables["tbl_Resource"].AsEnumerable(),
                q => q.OriginalResourceID,
                r => r.Field<int>("ResourceID"),
                (q, r) => new { q, r });
        ...
