    public bool BatchInsert(string table, IEnumerable<string> values)
        {
            var sql = new StringBuilder();
            sql.Append("INSERT INTO " + table + " VALUES(");
            var newValues = values.Where(x => !x.StartsWith("LIFT")).Select(x => string.Format("'{0}'", x.Replace("'", "''")));
            sql.Append(string.Join("","", newValues.ToArray()));
            sql.Append(")");
            using (var comm = new SqlCommand(statement, connectionPCICUSTOM))
            {
                try
                {
                    comm.Connection.Open();
                    comm.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    KaplanFTP.errorMsg = "Database error: " + e.Message;
                }
                finally
                {
                    comm.Connection.Close();
                }
            }
            return true;
        }
