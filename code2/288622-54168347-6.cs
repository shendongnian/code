     public interface IDatabaseHub
        {
       long Execute<TModel>(string storedProcedureName, TModel model, string dbName);
    
            /// <summary>
            /// This method is used to execute the stored procedures with parameter.This is the generic version of the method.
            /// </summary>
            /// <param name="storedProcedureName">This is the type of POCO class that will be returned. For more info, refer to https://msdn.microsoft.com/en-us/library/vstudio/dd456872(v=vs.100).aspx. </param>
            /// <typeparam name="TModel"></typeparam>
            /// <param name="model">The model object containing all the values that passes as Stored Procedure's parameter.</param>
            /// <returns>Returns how many rows have been affected.</returns>
            Task<long> ExecuteAsync<TModel>(string storedProcedureName, TModel model, string dbName);
    
            /// <summary>
            /// This method is used to execute the stored procedures with parameter. This is the generic version of the method.
            /// </summary>
            /// <param name="storedProcedureName">Stored Procedure's name. Expected to be a Verbatim String, e.g. @"[Schema].[Stored-Procedure-Name]"</param>
            /// <param name="parameters">Parameter required for executing Stored Procedure.</param>        
            /// <returns>Returns how many rows have been affected.</returns>         
            long Execute(string storedProcedureName, DynamicParameters parameters, string dbName);
    
            /// <summary>
            /// 
            /// </summary>
            /// <param name="storedProcedureName"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            Task<long> ExecuteAsync(string storedProcedureName, DynamicParameters parameters, string dbName);
    }
