    StringBuilder sb = new StringBuilder();
            SaveFileDialog fileSave = new SaveFileDialog();
            IEnumerable<string> columnNames = tbCifSil.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));
            foreach (DataRow row in tbCifSil.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field =>string.Concat("\"", field.ToString().Replace("\"", "\"\""), "\""));
                sb.AppendLine(string.Join(",", fields));
            }
            fileSave.ShowDialog();
            File.WriteAllText(fileSave.FileName, sb.ToString());
