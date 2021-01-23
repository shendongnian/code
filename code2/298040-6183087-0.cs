    var dt = new DataTable();
    dt.Columns.Add(new DataColumn("SrNo", typeof (int)));
    dt.Columns.Add(new DataColumn("Roll", typeof(int)));
    dt.Columns.Add(new DataColumn("Name", typeof(string)));
    dt.Rows.Add(1, 1, "XYZ");
    dt.Rows.Add(99, 45, "ABC");
    dt.Rows.Add(150, 120, "ROQ");
    dt.Rows.Add(10, 9, "RTY");
    var result1 = from r in dt.AsEnumerable()
                  where r.Field<int>("Roll") >= 0 && r.Field<int>("Roll") <= 100
                  select r;
    var result2 = from r in dt.AsEnumerable()
                  where r.Field<int>("Roll") >= 100 && r.Field<int>("Roll") <= 200
                  select r;
