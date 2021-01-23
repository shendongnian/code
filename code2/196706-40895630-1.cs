            DynamicParameters Params = new DynamicParameters();
            Params.Add("@ProfileID", ProfileID);
            Params.Add("@CategoryName", CategoryName);
            Params.Add("@Added", dbType: DbType.String, direction: ParameterDirection.Output,size:10);
            db.Execute(sql, Params, commandType: CommandType.StoredProcedure, commandTimeout: 60);
            var Added = Params.Get<string>("@Added");
