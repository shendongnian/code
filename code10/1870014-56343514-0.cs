        IDbConnection con = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        var query = await con.QueryAsync<ConsumoViewModel>("GetConsumoCalculado", commandType: CommandType.StoredProcedure);
        
        return new JsonResult(query.ToList());
    }
