                      protected void Page_Load(object sender, EventArgs e)
                          {
                             string path = @"C:\samples\firstexcel.xlsx";
                             GetExcelSheetNames(path);
                           }
    
                     private void GetExcelSheetNames(string excelFile)
                         {
                         OleDbConnection objConn = null;
                         System.Data.DataTable dt = null;
                         try
                         {
                        DataSet ds = new DataSet();
                      // Connection String. 
                           String connString = @"Data Source=" + excelFile +            ";Provider=Microsoft.ACE.OLEDB.12.0; Extended Properties=Excel 12.0;";
                      // Create connection. 
                      objConn = new OleDbConnection(connString);
                   // Opens connection with the database. 
                       objConn.Open();
                    // Get the data table containing the schema guid, and also sheet names. 
                     dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                     if (dt == null)
                {
                    return;
                }
                String[] excelSheets = new String[dt.Rows.Count];
                int i = 0;
                // Add the sheet name to the string array. 
                // And respective data will be put into dataset table 
                foreach (DataRow row in dt.Rows)
                {
    
                    excelSheets[i] = row["TABLE_name"].ToString();
    
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + excelSheets[i] + "]", objConn);
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    oleda.Fill(ds, "TABLE");
                    i++;
                }
                // Bind the data to the GridView 
                GridView1.DataSource = ds.Tables[0].DefaultView;
                GridView1.DataBind();
                Session["Table"] = ds.Tables[0];
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
    
            }
            finally
            {
                // Clean up. 
                if (objConn != null)
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
    
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = ((DataTable)Session["Table"]).DefaultView;
            GridView1.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }
    }
