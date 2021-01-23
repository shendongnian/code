    public void createsqltable(DataTable dt,string tablename)
            {
                string strconnection = "";
                string table = "";
                table += "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + tablename + "]') AND type in (N'U'))";
                table += "BEGIN ";
                table += "create table " + tablename + "";
                table += "(";
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (i != dt.Columns.Count-1)
                        table += dt.Columns[i].ColumnName + " " + "varchar(max)" + ",";
                    else
                        table += dt.Columns[i].ColumnName + " " + "varchar(max)";
                }
                table += ") ";
                table += "END";
                InsertQuery(table,strconnection);
                CopyData(strconnection, dt, tablename);
            }
            public void InsertQuery(string qry,string connection)
            {
    
    
                SqlConnection _connection = new SqlConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = qry;
                cmd.Connection = _connection;
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
            }
            public static void CopyData(string connStr, DataTable dt, string tablename)
            {
                using (SqlBulkCopy bulkCopy =
                new SqlBulkCopy(connStr, SqlBulkCopyOptions.TableLock))
                {
                    bulkCopy.DestinationTableName = tablename;
                    bulkCopy.WriteToServer(dt);
                }
            }
