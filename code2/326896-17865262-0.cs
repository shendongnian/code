    var p = new DynamicParametersWithTVP();
    p.Add( "@someVar", "abc", DbType.AnsiString );
    p.AddTVPString( "@stringlist", new string[] { "abc", "def" } );
    
    using (var conn = new SqlConnection( _cs )) {
        conn.Open();
        return conn.Query( "dbo.stored_proc_name", p, commandType: CommandType.StoredProcedure );
    }
