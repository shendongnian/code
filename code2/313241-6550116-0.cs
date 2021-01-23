       public void CreateDB(Table tbl)
               {
                  try
                        {
                            OpenDB();
                            //-- Structure Command
                            string strCommand = "CREATE TABLE " + tbl.TableName + " (";
                            
                            foreach (Column col in tbl.Columns)
                            {
                                strCommand += " " + col.ColumnName + " " + col.ColumnType + " ";
                                if (tbl.Columns.Count != tbl.Columns.IndexOf(col) + 1)//check if the object is last in the list
                                {
                                    if (col.ColKey != Key.None)
                                        strCommand += col.ColKey + " key ,";
                                    else
                                        strCommand += " ,";
                                }
                                else 
                                {
                                    if (col.ColKey != Key.None)
                                        strCommand += col.ColKey + " key";
                                    else
                                        strCommand += "";
                                }
                            }
            
                            strCommand += ")";
                            //---
                            SqliteCommand cmd = Connection.CreateCommand();
                            cmd.CommandText = strCommand;
                            cmd.ExecuteNonQuery();
                            CloseDB();
                        }
                        catch(SqliteExecutionException ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
    }
