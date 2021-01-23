         public class DatabaseHub : Connection, IDatabaseHub
            {
    
     /// <summary>
            /// This function is used for validating if the Stored Procedure's name is correct.
            /// </summary>
            /// <param name="storedProcedureName">Stored Procedure's name. Expected to be a Verbatim String, e.g. @"[Schema].[Stored-Procedure-Name]"</param>
            /// <returns>Returns true if name is not empty and matches naming patter, otherwise returns false.</returns>
    
            private static bool IsStoredProcedureNameCorrect(string storedProcedureName)
            {
                if (string.IsNullOrEmpty(storedProcedureName))
                {
                    return false;
                }
    
                if (storedProcedureName.StartsWith("[") && storedProcedureName.EndsWith("]"))
                {
                    return Regex.IsMatch(storedProcedureName,
                        @"^[\[]{1}[A-Za-z0-9_]+[\]]{1}[\.]{1}[\[]{1}[A-Za-z0-9_]+[\]]{1}$");
                }
                return Regex.IsMatch(storedProcedureName, @"^[A-Za-z0-9]+[\.]{1}[A-Za-z0-9]+$");
            }
    
         /// <summary>
                /// This method is used to execute the stored procedures without parameter.
                /// </summary>
                /// <param name="storedProcedureName">Stored Procedure's name. Expected to be a Verbatim String, e.g. @"[Schema].[Stored-Procedure-Name]"</param>
                /// <param name="model">The model object containing all the values that passes as Stored Procedure's parameter.</param>
                /// <typeparam name="TModel">This is the type of POCO class that will be returned. For more info, refer to https://msdn.microsoft.com/en-us/library/vstudio/dd456872(v=vs.100).aspx. </typeparam>
                /// <returns>Returns how many rows have been affected.</returns>
        
                public long Execute<TModel>(string storedProcedureName, TModel model, string dbName)
                {
                    if (!IsStoredProcedureNameCorrect(storedProcedureName))
                    {
                        return 0;
                    }
        
                    using (var connection = LiveConnection(dbName))
                    {
                        try
                        {
                            return connection.Execute(
                                sql: storedProcedureName,
                                param: model,
                                commandTimeout: null,
                                commandType: CommandType.StoredProcedure
                                );
        
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                        finally
                        {
                            CloseConnection(connection);
                        }
                    }
                }
        
                public async Task<long> ExecuteAsync<TModel>(string storedProcedureName, TModel model, string dbName)
                {
                    if (!IsStoredProcedureNameCorrect(storedProcedureName))
                    {
                        return 0;
                    }
        
                    using (var connection = LiveConnection(dbName))
                    {
                        try
                        {
                            return await connection.ExecuteAsync(
                                sql: storedProcedureName,
                                param: model,
                                commandTimeout: null,
                                commandType: CommandType.StoredProcedure
                                );
        
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                        finally
                        {
                            CloseConnection(connection);
                        }
                    }
                }
        
                /// <summary>
                /// This method is used to execute the stored procedures with parameter. This is the generic version of the method.
                /// </summary>
                /// <param name="storedProcedureName">Stored Procedure's name. Expected to be a Verbatim String, e.g. @"[Schema].[Stored-Procedure-Name]"</param>
                /// <param name="parameters">Parameter required for executing Stored Procedure.</param>        
                /// <returns>Returns how many rows have been affected.</returns>
        
                public long Execute(string storedProcedureName, DynamicParameters parameters, string dbName)
                {
                    if (!IsStoredProcedureNameCorrect(storedProcedureName))
                    {
                        return 0;
                    }
        
                    using (var connection = LiveConnection(dbName))
                    {
                        try
                        {
                            return connection.Execute(
                                sql: storedProcedureName,
                                param: parameters,
                                commandTimeout: null,
                                commandType: CommandType.StoredProcedure
                                );
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                        finally
                        {
                            CloseConnection(connection);
                        }
                    }
                }
        
        
        
                public async Task<long> ExecuteAsync(string storedProcedureName, DynamicParameters parameters, string dbName)
                {
                    if (!IsStoredProcedureNameCorrect(storedProcedureName))
                    {
                        return 0;
                    }
        
                    using (var connection = LiveConnection(dbName))
                    {
                        try
                        {
                            return await connection.ExecuteAsync(
                                sql: storedProcedureName,
                                param: parameters,
                                commandTimeout: null,
                                commandType: CommandType.StoredProcedure
                                );
        
                        }
                        catch (Exception exception)
                        {
                            throw exception;
                        }
                        finally
                        {
                            CloseConnection(connection);
                        }
                    }
                }
        
        }
