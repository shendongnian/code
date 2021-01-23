    OleDbCommand cmd = new OleDbCommand(
       "INSERT INTO tblCompany (CoCode,CoName_mar)
       VALUES(@ParamCoCode, @ParamCoName_mar)", con);
    OleDbParameter paramCoCode = new OleDbParameter();
    paramCoCode.ParameterName = "@ParamCoCode";
    paramCoCode.SqlDbType = SqlDbType.NVarChar;
    paramCoCode.Value = categoryName;
    OleDbParameter paramCoName_mar = new OleDbParameter ();
    paramCoName_mar.ParameterName = "@ParamCoCode";
    paramCoName_mar.SqlDbType = SqlDbType.NVarChar;
    paramCoName_mar.Value = categoryName;
    // Add the parameters to the Parameters collection. 
    cmdParameters.Add(paramCoCode);
    cmdParameters.Add(paramCoName_mar);
    cmd.ExecuteNonQuery();
    con.Close();
