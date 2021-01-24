        static void Main(string[] args)
        {
            var table1 = new DataTable();
            table1.Columns.Add("col1", typeof(string));
            table1.Columns.Add("col2", typeof(string));
            table1.Columns.Add("col3", typeof(string));
            table1.Columns.Add("col4", typeof(string));
            var row = table1.NewRow();
            row["col1"] = "1";
            row["col2"] = "1";
            row["col3"] = "1";
            row["col4"] = "something different";
            table1.Rows.Add(row);
            row = table1.NewRow();
            row["col1"] = "2";
            row["col2"] = "2";
            row["col3"] = "2";
            row["col4"] = "something different";
            table1.Rows.Add(row);
            var table2 = new DataTable();
            table2.Columns.Add("col1", typeof(string));
            table2.Columns.Add("col2", typeof(string));
            table2.Columns.Add("col3", typeof(string));
            table2.Columns.Add("col4", typeof(string));
            row = table2.NewRow();
            row["col1"] = "1";
            row["col2"] = "1";
            row["col3"] = "1";
            row["col4"] = "Another different thing";
            table2.Rows.Add(row);
            var results = (
                from t1 in table1.AsEnumerable()
                join t2 in table2.AsEnumerable() on
                    new { a = t1["col1"], b = t1["col2"], c = t1["col3"] } equals
                    new { a = t2["col1"], b = t2["col2"], c = t2["col3"] }
                    into joinedComboTable
                select joinedComboTable).ToList();
            //Result
            var newTable = results.FirstOrDefault()?.CopyToDataTable();
        }
