    protected void GridView1_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow & e.Row.RowIndex!=11)
      {
        e.Row.Attributes["onclick"] = 
        Page.ClientScript.GetPostBackClientHyperlink(TakeGrid, "Select$" + e.Row.RowIndex);
      }
    }
