    try
                {
                    string connectionString = string.Empty;
                  
                    if (Path.GetExtension(ExcelFileName) == ".xlsx")
                    {
                        connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelFileName +
                            ";Extended Properties=Excel 12.0;";
                    }
                    else
                    {
                        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExcelFileName + ";Extended Properties=Excel 8.0;";
                    }
    
                    OleDbCommand selectCommand = new OleDbCommand();
                    OleDbConnection connection = new OleDbConnection();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    connection.ConnectionString = connectionString;
    
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
    
                    DataTable dtSchema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    
                    List<string> SheetsName = GetSheetsName(dtSchema);
                    for (int i = 0; i < SheetsName.Count; i++)
                    {
                        selectCommand.CommandText = "SELECT * FROM [" + SheetsName[i] + "]";
                        selectCommand.Connection = connection;
                        adapter.SelectCommand = selectCommand;
                        DataTable Sheet = new DataTable();
                        Sheet.TableName = SheetsName[i].Replace("$", "").Replace("'", "");
                        adapter.Fill(Sheet);
    
                        if (Sheet.Rows.Count > 0)
                        {
                            Records.Tables.Add(Sheet);                        
                        }
                    }
                }
                catch (Exception ex)
                {
                    WriteLog(ex);
                }
