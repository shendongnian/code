    string strConnectionString = @"Server=bisweb\bisweb;Database=x_kgabo;Trusted_Connection=true;";
    string storedProcName = "usp_insertempdata";
    using(SqlConnection _SqlConnection = new SqlConnection(strConnectionString))
    using(SqlCommand cmd = new SqlCommand(storedProcName, _SqlConnection))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        Int32 rowsAffected;
        ......
    }
