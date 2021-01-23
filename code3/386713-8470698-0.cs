    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // searching through the rows
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          if(int.Parse(DataBinder.Eval(e.Row.DataItem,"Risk").ToString()) > 100)
            {
                e.Row.BackColor = Color.FromName("#FAF7DA"); // is a "new" row
            }
        }
    }
