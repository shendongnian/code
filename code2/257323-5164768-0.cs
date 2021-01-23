      var dt = new DataTable();
      dt.Columns.Add(new DataColumn("Id", typeof(int)));
      dt.Columns.Add(new DataColumn("Project Name", typeof(string)));
      dt.Columns.Add(new DataColumn("Project Date", typeof(DateTime)));
    
      for (int i = 0; i < 10; i++)
      {
        var row = dt.NewRow();
        row.ItemArray = new object[] { i, "SomeProjectName", DateTime.Now.AddDays(i * -1) };
        dt.Rows.Add(row);
      }
