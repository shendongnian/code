    public async Task<List<ManualReadTag>> GetManuallyReadTagsAsync(ParameterManualTags model)
    {
        var db = new ApplicationDbContext();
        using (var cnxn = db.Database.Connection)
        {
            using (var cmd = cnxn.CreateCommand())
            {
                cmd.CommandText = "GetManualReadForDedicated";
                cmd.CommandType = CommandType.StoredProcedure;
    
                var dtFrom = cmd.CreateParameter();
                dtFrom.ParameterName = "@DateFrom";
                dtFrom.DbType = DbType.Date;
                dtFrom.Direction = ParameterDirection.Input;
                dtFrom.Value = model.DateFrom;
    
                var dTo = cmd.CreateParameter();
                dTo.ParameterName = "@DateTo";
                dTo.DbType = DbType.Date;
                dTo.Direction = ParameterDirection.Input;
                dTo.Value = model.DateTo;
    
                var lane = cmd.CreateParameter();
                lane.ParameterName = "@Lane";
                lane.DbType = DbType.Int32;
                lane.Direction = ParameterDirection.Input;
                lane.Value = model.Lane;
    
                var plaza = cmd.CreateParameter();
                plaza.ParameterName = "@Plaza";
                plaza.DbType = DbType.String;
                plaza.Direction = ParameterDirection.Input;
                plaza.Value = model.Plaza;
    
                cmd.Parameters.Add(dtFrom);
                cmd.Parameters.Add(dTo);
                cmd.Parameters.Add(lane);
                cmd.Parameters.Add(plaza);
    
                await cnxn.OpenAsync();
    
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    var result = ((IObjectContextAdapter)db)
                        .ObjectContext
                        .Translate<ManualReadTag>(reader)
                        .ToList();
                    return result;
                }
            }
        }
    }
