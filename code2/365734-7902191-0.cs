        DataTable dt = new DataTable("aaa");
        dt.Columns.Add("pieces", typeof(int));
        dt.Rows.Add(new object[] { 1 });
        dt.Rows.Add(new object[] { 3 });
        dt.Rows.Add(new object[] { 5 });
        var sum = dt.Compute("SUM(pieces)", string.Empty);
