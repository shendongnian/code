    string fileName = string.Format("{0}", AppDomain.CurrentDomain.BaseDirectory);   
    string connectionString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; " + "Extended Properties=\"text;HDR=YES;FMT=TabDelimited;\"", fileName);
    string sql = "select * from " + "Data.txt";
    
    OleDbConnection con = new OleDbConnection(connectionString);
    con.Open();
    OleDbDataAdapter dap = new OleDbDataAdapter(sql, con);
    DataTable dt = new DataTable();
    dt.TableName = "Data";
    dap.Fill(dt);
    con.Close();
