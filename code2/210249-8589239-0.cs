    `enter code here`Create and save an schema.ini file into the application folder containing the following text:
    ------------------Schema.ini file starts here-----------------
    [Data.txt]
    ColNameHeader=True
    Format=TabDelimited
    Col1=First_Name Text
    Col2=Middle_Initial Text
    Col3=Last_Name Text
    ------------------Schema.ini file ends here-----------------
    
    Then use the following code to load the Data.txt file:
    
     string fileName = string.Format("{0}", AppDomain.CurrentDomain.BaseDirectory);
    
                        string connectionString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; " +
                                                                "Extended Properties=\"text;HDR=YES;FMT=TabDelimited;\"", fileName);
                        
                        string sql = "select * from " + "Data.txt";
    
                        OleDbConnection con = new OleDbConnection(connectionString);
    
                        con.Open();
    
                        OleDbDataAdapter dap = new OleDbDataAdapter(sql, con);
                        DataTable dt = new DataTable();
    
                        dt.TableName = "Data";
                        dap.Fill(dt);
