    using System.Data.OleDb;
    
    
    private void SelectItem() 
            { 
                ExcelSheetName = excelSheetsListBox.SelectedItem != null ? 
                    excelSheetsListBox.SelectedItem.ToString() : string.Empty; 
                Close(); 
            }
    
    private void PopulateSheetsOfExcelFile(string excelFilePath) 
            { 
                try 
                { 
                    String connString = string.Empty;
    
                    try 
                    { 
                                          connString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"", excelFilePath); 
                        using (OleDbConnection objConn = new OleDbConnection(connString)) 
                        { 
                            objConn.Open(); 
                            using (DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null)) 
                            { 
                                if (dt == null) 
                                    return;
    
                                excelSheetsListBox.Items.Clear();
    
                                for (int i = 0; i < dt.Rows.Count; i++) 
                                { 
                                    DataRow row = dt.Rows[i]; 
                                    excelSheetsListBox.Items.Add(row["TABLE_NAME"].ToString()); 
                                } 
                            } 
                        } 
                    } 
                    catch (Exception exA1) 
                    { 
                                            connString = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"", excelFilePath); 
                        using (OleDbConnection objConn = new OleDbConnection(connString)) 
                        { 
                            objConn.Open(); 
                            using (DataTable dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null)) 
                            { 
                                if (dt == null) 
                                    return;
    
                                excelSheetsListBox.Items.Clear();
    
                                for (int i = 0; i < dt.Rows.Count; i++) 
                                { 
                                    DataRow row = dt.Rows[i]; 
                                    excelSheetsListBox.Items.Add(row["TABLE_NAME"].ToString()); 
                                } 
                            } 
                        } 
                    } 
                } 
                catch (Exception ex) 
                { 
                   MessageBox.Show(“HATA”);
    
                    ExcelSheetName = string.Empty; 
                    Close(); 
                } 
            }
