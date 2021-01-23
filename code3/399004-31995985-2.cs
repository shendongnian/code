    using (var c = SqlConnection(connstring))
    {
        c.Open();
        var p = new DynamicParameters();
        // fill out p
    
        c.Execute("xp_backup_database", p, commandTimeout: 60, 
                                           commandType: CommandType.StoredProcedure);
    }
