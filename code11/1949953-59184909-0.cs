    var compiler = new SqlServerCompiler();
    var query =
        new Query("ChannelData")
        .AsInsert(
            new[] { "ChannelID", "DataSource", "X","Y" },
            new Query("Channels")
            .Select("ChannelID", "DataSource", "X", "Y")
            .Where("Channel","N01E")
            .Where("Revision",0)
        );
    var rawSql = compiler.Compile(query).RawSql;
