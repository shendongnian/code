    StringBuilder sb = new StringBuilder();
            foreach (DataColumn col in table.Columns)
            {
                sb.Append(col.ColumnName + ";");
            }
            foreach (DataRow row in table.Rows)
            {
                sb.AppendLine();
                foreach (DataColumn col in table.Columns)
                {
                    sb.Append($@"{Convert.ToString(row[col])}" + ";");
                }
            }
            File.WriteAllText(path, sb.ToString());
