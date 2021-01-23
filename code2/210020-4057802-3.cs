    string queryStmt = "INSERT INTO dbo.YourTable(Content) VALUES(@Content)";
    using(SqlConnection _con = new SqlConnection (--your-connection-string-here--))
    using(SqlCommand _cmd = new SqlCommand (queryStmt, _con))  
    {
       SqlParameter param = _cmd.Parameters.Add("@Content", SqlDbType.VarBinary);
       param.Value = YourByteArrayVariableHere;
       _con.Open();
       _cmd.ExecuteNonQuery();
       _con.Close();
    }
