        ActiveModule resultObject = null;
        StringBuilder sqlStringBuilder = new StringBuilder();
        sqlStringBuilder.AppendLine("SELECT * FROM suite_activemodule as _module");
        sqlStringBuilder.AppendLine("WHERE CityID = @CityID AND BaseModuleID = @BaseModuleID");
        using (MySqlConnection connection = new MySqlConnection(ConnectionString))
        {
            resultObject = connection.QueryFirstOrDefault<ActiveModule>(sqlStringBuilder.ToString(), new { CityID = cityID, BaseModuleID = moduleID });            
            if (resultObject != null)
            {
                resultObject.Module = BaseModuleRepository.GetByID(resultObject.ModuleID);
            }
        }
