    for (int i = 0; i < dsUpload.Tables[0].Columns.Count; i++)
                        {
                            if (dsUpload.Tables[0].Columns[i].ColumnName.ToString() != "")
                            {
                                // Assigning ColumnName
                                objExcelUpload.ColumnName = dsUpload.Tables[0].Columns[i].ColumnName.ToString().Replace("'", "''").Replace("<", "&lt;").Replace(">", "&gt;").Trim();
                                if (!objExcelUpload.ifColumnNameExist("insert"))
                                {
                                    if (objExcelUpload.ColumnName != "")
                                    {
                                        objExcelUpload.insertColumns();    
                                    }
                                    
                                }
                                else
                                {
                                    ErrorLabel.Text = "The column name already exists. Please select a different name.";
                                    return;
                                }
                                
                            }
                        }
