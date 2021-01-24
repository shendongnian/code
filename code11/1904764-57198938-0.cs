     public void writeColumns(System.Data.DataTable table, string filepath)
     {
            StringBuilder sb = new StringBuilder();
            foreach (DataColumn col in table.Columns)
            {
                sb.Append(col.ColumnName + ";");
            }
            System.IO.File.WriteAllText(filepath, sb.ToString());
     }
