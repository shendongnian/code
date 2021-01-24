csharp
using (OracleConnection connection = new OracleConnection(oracleStgConnectionString))
using (OracleCommand command = connection.CreateCommand())
{
    connection.Open();
    command.BindByName = true;
    command.CommandType = CommandType.StoredProcedure;
    command.CommandText = "OtherSchema.P_CloseBatch";
    command.Parameters.Add(new OracleParameter()
    {
        ParameterName = "batchname",
        OracleDbType = OracleDbType.NVarchar2
        Value = parameterBatchName
    });
    command.ExecuteNonQuery();
    // Call to connection.Close removed as the "using" block already does that.
}
I've thrown in a few other changes:
* Created `command` using `connection.CreateCommand` because it assigns the connection before returning the object.
* A `using` block on `command` because it's also disposable.
* Setting `BindByName` so the parameter name I specify actually means something.
