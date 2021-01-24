    ```c#
    paramParam1 = new SqlParameter("param1", SqlDbType.VarBinary, 500);
    // paramParam1.Direction = ParameterDirection.Input; // Input is default / assumed
    paramParam1.Value = param1;
    sqlCommand.Parameters.Add(paramParam1);
    paramParam2 = new SqlParameter("param2", SqlDbType.Int);
    paramParam2.Direction = ParameterDirection.Output;
    paramParam2.Value = intVariable;
    sqlCommand.Parameters.Add(paramParam2);
    ```
