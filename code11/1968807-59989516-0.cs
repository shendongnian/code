    private void OnRowDataBound(Object sender, GridViewRowEventArgs e)
    {
      for (int i = 4; i <= 6; i++)
           if(e.Row.Cells[1].Text == "&nbsp;")
              e.Row.Cells[i].BackColor = System.Drawing.Color.White;
    }
