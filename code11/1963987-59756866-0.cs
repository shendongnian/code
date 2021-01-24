    string BulkGetColumn3Query(List<string> column3Values) {
        var selectList = string.Join(", ", column3Values.Select((_, i) => $"@p{i}"));
        return $@"SELECT Column1, Column2
                FROM TABLE
                WHERE  column3 IN ({selectList})";
    }
    async Task<List<EntityObject>> GetModelObjectByColumn3(List<string> column3Values)
    {
       var query = BulkGetColumn3Query(column3Values);
       var sqlParameters = new List<SqlParameter>();
       return await Trailers
            .FromSqlRaw(query, column3Values.Select((val, i) => new SqlParameter($"@p{i}", val)))
            .AsNoTracking()
            .ToListAsync();
    }
