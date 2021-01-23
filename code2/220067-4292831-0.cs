     if (DGV.Columns.Contains("yourColumn") && e.Column == dataGridView1.Columns["Products"])
     {
          DGV.Columns["yourColumn"].Width = e.Column.Width;
     }
   
