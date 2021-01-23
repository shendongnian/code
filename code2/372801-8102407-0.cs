    OleDbConnection myConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"Database.accdb\";Persist Security Info=False;");
                    //command to insert each ASIN
                    OleDbCommand cmd = new OleDbCommand();
                    //command to update each column (ASIN, Retail... from CSV)
                    OleDbCommand cmd1 = new OleDbCommand();
                    //load csv data to dtCSV datatabe
                    DataTable dtCSV = new DataTable();
                    dtCSV = ds.Tables[0];
                    // Now we will collect data from data table and insert it into database one by one
                    // Initially there will be no data in database so we will insert data in first two columns
                    // and after that we will update data in same row for remaining columns
                    // The logic is simple. 'i' represents rows while 'j' represents columns
                    cmd.Connection = myConnection;
                    cmd.CommandType = CommandType.Text;
                    cmd1.Connection = myConnection;
                    cmd1.CommandType = CommandType.Text;
                    myConnection.Open();
                    for (int i = 0; i <= dtCSV.Rows.Count - 1; i++)
                    {
                        cmd.CommandText = "INSERT INTO " + lblTable.Text + "(ID, " + dtCSV.Columns[0].ColumnName.Trim() + ") VALUES (" + (i + 1) + ",'" + dtCSV.Rows[i].ItemArray.GetValue(0) + "')";
                        cmd.ExecuteNonQuery();
                        for (int j = 1; j <= dtCSV.Columns.Count - 1; j++)
                        {
                            cmd1.CommandText = "UPDATE " + lblTable.Text + " SET [" + dtCSV.Columns[j].ColumnName.Trim() + "] = '" + dtCSV.Rows[i].ItemArray.GetValue(j) + "' WHERE ID = " + (i + 1);
                            cmd1.ExecuteNonQuery();
                        }
                    }
                    myConnection.Close();
