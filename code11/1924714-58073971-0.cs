     foreach (DataColumn dc in sampleDataTable.Columns) //looping through DataTable columns
      {
      
       var idx = ws.Cells["1:1"].First(c => c.Value.ToString() == dc.ColumnName.ToString()).Start.Column;
       ws.Column(idx).Style.WrapText = true; // wrapping applying to entire column
      
      }
