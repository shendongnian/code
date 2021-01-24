foreach (DataRow row in table.Rows)
                    {
                        string columnvalues = "'";
                        for (int i = 0; i < columnCount; i++)
                        {
                            int index = table.Rows.IndexOf(row);
                            columnvalues += table.Rows[index].ItemArray[i];
                            columnvalues += "','";
                            //MessageBox.Show(columnvalues);
                        }
                        columnvalues = columnvalues.TrimEnd('\'');
                        columnvalues = columnvalues.TrimEnd(',');
                        var command = sqlCommandInsert + columnvalues + ")";
                        //MessageBox.Show(command);
                        Excel_OLE_Cmd.CommandText = command;
                        Excel_OLE_Cmd.ExecuteNonQuery();
                    }
