    DataTable dt = new DataTable();
    (from a1 in context.Table1.Where(i => i.Attribute3 != "").AsEnumerable()
     from a2 in context.Table1.Where(i => i.Attribute1 != "").AsEnumerable()
       select new
              {
                Attribute = a2.Attribute1 ?? a1.Attribute3
                //etc
              }).Aggregate(table, (dt, r) =>
              {
                dt.Rows.Add(r.Attribute);
                return dt;
              });
