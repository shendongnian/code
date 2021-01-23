    public Task<long> DeleteFuelPriceEntryByID(string FuelPriceId, string UserId)
            {
    
        
                var parameters = new DynamicParameters();
                parameters.Add(name: "@FuelPriceId", value: FuelPriceId, dbType: DbType.Int32, direction: ParameterDirection.Input);
                parameters.Add(name: "@UserId", value: UserId, dbType: DbType.String, direction: ParameterDirection.Input);
    
                return DatabaseHub.ExecuteAsync(
                        storedProcedureName: @"[dbo].[sp_Delete_FuelPriceEntryByID]", parameters: parameters, dbName: AMSDB);
    
            }
