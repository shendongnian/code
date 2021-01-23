    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
          HyperLink hpl = (HyperLink)e.Row.Cells[0].FindControl("hyplink");
          hpl.Attributes.Add("rel", "insert");
          LinkButton lkb = (LinkButton)e.Row.Cells[0].FindControl("link");
          lkb.Attributes.Add("rel", "insert");
       }
    }
