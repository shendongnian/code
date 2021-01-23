        public static IEnumerable<string> GetInsertQueryFromDataTable(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.AsEnumerable())
            {
                var s = new StringBuilder(string.Format("INSERT INTO {0} SET ", dataTable.TableName));
                foreach (DataColumn v in dataTable.Columns)
                {
                    var r = new StringBuilder(row[v.ColumnName].ToString());
                    r.Replace("\"", "\\\"");
                    s.AppendFormat("{0}=\"{1}\", ", v.ColumnName, r);
                }
                s.Remove(s.Length - 2, 1);
                s.AppendLine(";");
                yield return s.ToString();
            }
        }
