        public static DataTable GetDataTablePart(this DataTable dt, params string[] ColumnNames)
        {
            var RowCount = 0;
            var dtPart = new DataTable("TablePart");
            dtPart.Columns.AddRange((from column in dt.Columns.Cast<DataColumn>()
                         where ColumnNames.Contains(column.ColumnName)
                         select column).ToArray());
            return (from row in dt.AsEnumerable()
                      let rowCount = RowCount = dt.Rows.Count
                      let RowValues = (from column in dtPart.Columns.Cast<DataColumn>()
                                       select row[column]).ToArray()
                      let decCount = RowCount = RowCount - 1
                      where dtPart.LoadDataRow(RowValues,LoadOption.OverwriteChanges) != default && decCount > 0
                      select dtPart).FirstOrDefault();
        }
