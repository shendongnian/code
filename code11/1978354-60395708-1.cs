    var dt = new DataTable();
            dt.Columns.Add("responseTime", typeof(decimal));
            dt.Columns.Add("url");            
            AddRow(dt, "Login.aspx", 2);
            AddRow(dt, "Login.aspx", 3);
            AddRow(dt, "Login.aspx", 4);
            AddRow(dt, "Login.aspx", 5);
            AddRow(dt, "WelcomePage.aspx", 6);
            AddRow(dt, "WelcomePage.aspx", 7);
            AddRow(dt, "WelcomePage.aspx", 8);
            AddRow(dt, "WelcomePage.aspx", 9);
            AddRow(dt, "LogOut.aspx", 10);
            AddRow(dt, "LogOut.aspx", 10);
            AddRow(dt, "LogOut.aspx", 11);
            AddRow(dt, "LogOut.aspx", 11);
            var result = (
                from row in dt.AsEnumerable()
                group row by new { Col1 = row["url"] } into g
                select new
                {
                    Col1 = g.Key.Col1,
                    AvgVal1 = g.Average(x => x.Field<decimal>("responseTime")),
                }
            ).ToList();
    static void AddRow(DataTable dt, string url, int responseTime)
    {
        var row = dt.NewRow();
        row["url"] = url;
        row["responseTime"] = responseTime;
        dt.Rows.Add(row);            
    }
