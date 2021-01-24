    private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
    {
      var dgv = sender as DataGridView;
      if (null != dgv)
      {
        var row = dgv.Rows[e.RowIndex];
        var drv = row.DataBoundItem as DataRowView;
        if (null != drv)
        {
          var dr = drv.Row as DataSet1.DataTable1Row;
          if (dr.IsNull(0))
          {
            dr.Path = string.Empty;
          }
        }
      }
    }
