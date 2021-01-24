        public static DataTable GetDataTablePart(this DataTable dt, params string[] ColumnNames)
        {
            var dtPart = new DataTable("TablePart");
            var Names = dt.Columns.OfType<DataColumn>().Where(x => ColumnNames.Contains(x.ColumnName)).ToArray();
            dtPart.Columns.AddRange(Names);
            foreach(DataRow row in dt.Rows)
            {
                var NewRow = new object[Names.Count()];
                var i = 0;
                foreach (var Name in Names)
                {
                    NewRow[i] = row[Name];
                    i = i + 1;
                }
                dtPart.LoadDataRow(NewRow, false);
            }
            return dtPart;
        }
