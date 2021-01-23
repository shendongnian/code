    // Initial Code for Testing
    DataTable dt = new DataTable();
    dt.Columns.Add("Dates", typeof(DateTime));
    dt.Rows.Add(new object[] { DateTime.Now });
    dt.Rows.Add(new object[] { DateTime.Now.AddDays(1) });
    dt.Rows.Add(new object[] { DateTime.Now.AddDays(2) });
