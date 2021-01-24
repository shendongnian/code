        public static DataTable GetDataTablePart(this DataTable dt, params string[] ColumnNames)
        {
            var dtPart = new DataTable("TablePart");
            var Names = new List<DataColumn>();
            foreach (DataColumn Column in dt.Columns)
            {
                if(ColumnNames.Contains(Column.ColumnName))
                {
                    Names.Add(Column);
                }
            }
            dtPart.Columns.AddRange(Names.ToArray());
            foreach(DataRow row in dt.Rows)
            {
                var NewRow = new object[Names.Count()];
                var i = 0;
                foreach (var Name in Names)
                {
                    NewRow[i] = row[Name];
                }
                dtPart.LoadDataRow(NewRow, false);
            }
            return dtPart;
        }
