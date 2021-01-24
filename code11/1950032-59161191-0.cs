    var compiler = new SqlServerCompiler();
    //var Table1 = "Table1";
    var query = new Query(null)
            .FromRaw("Table1 INNER JOIN Table2 " +
            "ON LEFT([Table1].[Company],5) = " +
            "LEFT([Table2].[Company],5)")
            .AsUpdate(new { scrub = "match" });
    var rawSql = compiler.Compile(query).RawSql;
