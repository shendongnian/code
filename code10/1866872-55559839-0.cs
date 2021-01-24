        var paramList = new[]
        {
            new SqlParameter("@Value", SqlDbType.VarChar).Value = "SomeValue",
            new SqlParameter("@FkId", SqlDbType.Int).Value = 123
        };
