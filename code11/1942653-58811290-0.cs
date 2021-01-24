    var spOutput = new SqlParameter("@RETVAL", System.Data.SqlDbType.VarChar)
    {
        Direction = System.Data.ParameterDirection.Output,
        Size = 12,
    };
    
    var sql = $";EXEC [dbo].[GenerateId] @@RETVAL = @0 OUTPUT";
    var sqlClass = new Sql();
    var s = sqlClass.Append(sql, spOutput);
    
    var response = await _dbAdapter.ExecuteAsync(s);
    return (string)spOutput.Value;
