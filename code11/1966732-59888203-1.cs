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
            //However to get col4 form table 2 you need to do this
            var result2 = (
                from t1 in table1.AsEnumerable()
                join t2 in table2.AsEnumerable() on
                    new { a = t1["col1"], b = t1["col2"], c = t1["col3"] } equals
                    new { a = t2["col1"], b = t2["col2"], c = t2["col3"] }
                select new { a = t1["col1"], b = t1["col2"], c = t1["col3"], d = t1["col4"], e = t2["col4"] });
            //Result
            var newTable2 = table1.Clone();
            newTable2.Columns.Add("col4FromTable2", typeof(string));
            foreach (var x1 in result2)
            {
                var r = newTable2.NewRow();
                r["col1"] = x1.a;
                r["col2"] = x1.b;
                r["col3"] = x1.c;
                r["col4"] = x1.d;
                r["col4FromTable2"] = x1.e;
                newTable2.Rows.Add(r);
            }
        }
