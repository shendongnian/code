                     string filePath = "C:\\Book1.xlsx";
                    string connString = string.Empty;
                    if (path.EndsWith(".xlsx"))
                    {
                        //2007 Format
                        connString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No'", path);
                    }
                    else
                    {
                        //2003 Format
                        connString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=No'", path);
                    }
                    using (OleDbConnection con = new OleDbConnection(connString))
                    {
                        using (OleDbCommand cmd = new OleDbCommand())
                        {
                            //Read the First Sheet
                            cmd.Connection = con;
                            con.Open();
                            DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            con.Close();
                            string firstSheet = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            //Read the Header Row
                            cmd.CommandText = "SELECT top 1 * From [" + firstSheet + "]";
                            using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
                            {
                                DataTable HeaderColumns = new DataTable();
                                da.SelectCommand = cmd;
                                da.Fill(HeaderColumns);
                                List<string> Filedata = new List<string>();
                                foreach (DataColumn column in HeaderColumns.Columns)
                                {
                                    string columnName = HeaderColumns.Rows[0][column.ColumnName].ToString();
                                    
                                    Filedata.Add(columnName);
                                    ViewBag.Data = Filedata;
                                }
                            }
                        }
                    }
