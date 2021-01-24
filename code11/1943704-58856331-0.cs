    string strquery = "SELECT PROC_INSERT_TEST(123,'Test3','Test3','T','T',";
    strquery = strquery + "'" + DateTime.Now.ToString("MMM-dd-yyyy HH:mm:ss") + "',1,9,1234,";
    strquery = strquery + "'" + DateTime.Now.ToString("MMM-dd-yyyy HH:mm:ss") + "')";
    
    NpgsqlCommand cmd = new NpgsqlCommand(strquery, _connection);
    _connection.Open();
    cmd.ExecuteNonQuery();
    cmd.Dispose();
    _connection.Close();
