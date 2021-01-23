        public static DataTable ConvertSqlDataReaderToDataTable(SqlDataReader reader)
        {
            ArrayList alColumns;
            DataColumn dcColumn;
            DataRow drRow;
            DataTable dtTemp;
            DataTable dtReturn;
            Int32 i;
            // create dataset to match the reader using reader's schema
            alColumns = new ArrayList();
            dtReturn = new DataTable();
            dtTemp = reader.GetSchemaTable();
            for (i = 0; i < dtTemp.Rows.Count; i++)
            {
                dcColumn = new DataColumn();
                if (!dtReturn.Columns.Contains(dtTemp.Rows[i]["ColumnName"].ToString()))
                {
                    dcColumn.ColumnName = dtTemp.Rows[i]["ColumnName"].ToString();
                    dcColumn.Unique = Convert.ToBoolean(dtTemp.Rows[i]["IsUnique"]);
                    dcColumn.AllowDBNull = Convert.ToBoolean(dtTemp.Rows[i]["AllowDBNull"]);
                    dcColumn.ReadOnly = Convert.ToBoolean(dtTemp.Rows[i]["IsReadOnly"]);
                    alColumns.Add(dcColumn.ColumnName);
                    dtReturn.Columns.Add(dcColumn);
                }
            }
            // read data into the dataset
            while (reader.Read())
            {
                drRow = dtReturn.NewRow();
                for (i = 0; i < alColumns.Count; i++)
                {
                    drRow[alColumns[i].ToString()] = reader[alColumns[i].ToString()];
                }
                dtReturn.Rows.Add(drRow);
            }
            return dtReturn;
        }
        public static DataTable GetTable()
        {
            DataTable dtReturn;
            SqlConnection connection = new SqlConnection(global::Project.Properties.Settings.Default.DBConnection);
            SqlCommand command;
            SqlDataReader reader;
            try
            {
                connection.Open();
                command = new SqlCommand("SELECT * FROM Table", connection);
                command.CommandType = CommandType.Text;
                reader = command.ExecuteReader(CommandBehavior.SingleResult);
                dtReturn = ConvertSqlDataReaderToDataTable(reader);
                dtReturn.TableName = command.CommandText;
                reader.Close();
            }
            catch (Exception e)
            {
                // ADD ERROR HANDLING HERE
                dtReturn = new DataTable();
            }
            finally
            {
                connection.Close();                
            }
            return dtReturn;
        }
<pre>
