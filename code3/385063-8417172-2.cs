    using (TestData ds = new TestData())
    {
          // Typed Rows
          ds.Models.AddModelsRow(1, 2);
          ds.Models.AddModelsRow(ds.Models.NewModelsRow()); // NULL INFO TEST
          // Untyped rows
          DataRow r = ds.Models.NewRow();
          r[0] = 4;
          r[1] = 5;
          ds.Models.Rows.Add(r);
          //query
          var list = from m in ds.Tables["Models"].AsEnumerable()
                     select new Model
                     {
                         // rest of members omitted to simplify
                         YearBegin = m.Field<int?>("YearBegin"),
                         YearEnd = m.Field<int?>("YearEnd"),
                     };
    }
