    void grvValidCourses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        System.Diagnostics.Trace.WriteLine(e.Row.Cells.Count);
         foreach (TableCell c in e.Row.Cells)
         {
          System.Diagnostics.Trace.WriteLine(c.Text);
         }
      }
    }
