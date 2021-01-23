    public IoSqlReply GetResultSet(String directoryName, String userId, String password, String sql)
    {
        IoSqlReply ioSqlReply = new IoSqlReply();
        DataTable dtResultSet = new DataTable();
        IoMsSQL ioMsSQL = null;
        bool keepProcessing = true;
        try
        {
            using (OdbcConnection conn = new OdbcConnection(cs))
            {
                conn.Open();
 
                while (keepProcessing)
                {
                   using (OdbcCommand cmd = new OdbcCommand(sql, conn))
                   {
                       using (OdbcDataReader reader = cmd.ExecuteReader())
                       {
                          if (reader.HasRows)
                          {
                            for (int col = 0; col < reader.FieldCount; col++)
                            {
                               String colName = reader.GetName(col);
                               String colDataType = reader.GetFieldType(col).ToString(); ;
                               dtResultSet.Columns.Add(reader.GetName(col),     reader.GetFieldType(col));
                            }
                            // now copy each row/column to the datatable
                            while (reader.Read())       // loop round all rows in the source table
                            {
                                DataRow row = dtResultSet.NewRow();
                                for (int ixCol = 0; ixCol < reader.FieldCount; ixCol++)     // loop round all columns in each row
                                {
                                    row[ixCol] = reader.GetValue(ixCol);
                                }
                               // -------------------------------------------------------------
                               // finished processing the row, add it to the datatable
                               // -------------------------------------------------------------
                                dtResultSet.Rows.Add(row);
                                GC.Collect();       // free up memory
                            }//closing while
                            ioSqlReply.DtResultSet = dtResultSet;       // return the data table
                            ioSqlReply.RowCount = dtResultSet.Rows.Count;
                            Console.WriteLine("DTRESULTSET:ROW COUNT FINAL : " + dtResultSet.Rows.Count);
                            ioSqlReply.Rc = 0;
                          }
                          else
                          {
                            keepProcessing = false;
                          }
                       }
                    }
                }
            }
        }
