            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\folder;Extended Properties=dBASE IV;User ID=;Password=;"); // give your path directly 
            try
            {
                con.Open();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from tblCustomers.DBF", con); // update this query with your table name 
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                int i = ds.Tables[0].Rows.Count;
                return true;
            }
            catch(Exception e)
            {
                var error = e.ToString();
                // check error details 
                return false;
            }
