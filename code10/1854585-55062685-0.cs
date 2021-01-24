string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelFile + ";Extended Properties=\"Excel 12.0;HDR=YES;TypeGuessRows=0;ImportMixedTypes=text;IMEX=1\"";
                objConn = new OleDbConnection(constring);
                objConn.Open();
                // Get the data table containg the schema guid.
                var dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                var query = "select * from [" + dt.Rows[0]["TABLE_NAME"].ToString() + "]";
                DataSet ds = new DataSet();
               
                OleDbConnection con = new OleDbConnection(constring + "");
                OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
                da.Fill(ds);
