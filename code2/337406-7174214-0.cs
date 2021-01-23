     public static void Write(DataTable dt, string filePath)
            {
                int i = 0;
                StreamWriter sw = null;
                    sw = new StreamWriter(filePath, false);
                    for (i = 0; i < dt.Columns.Count - 1; i++)
                    {
                        sw.Write(dt.Columns[i].ColumnName + " ");
                    }
                    sw.Write(dt.Columns[i].ColumnName);
                    sw.WriteLine();
                    foreach (DataRow row in dt.Rows)
                    {
                        object[] array = row.ItemArray;
                        for (i = 0; i < array.Length - 1; i++)
                        {
                            sw.Write(array[i] + " ");
                        }
                        sw.Write(array[i].ToString());
                        sw.WriteLine();
                    }
                    sw.Close();
            }
