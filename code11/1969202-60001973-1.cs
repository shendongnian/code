    protected void GridView1_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        e.Row.Attributes["onclick"] = 
        Page.ClientScript.GetPostBackClientHyperlink(TakeGrid, "Select$" + e.Row.RowIndex);
       e.Row.Cells[11].Attributes.Remove("onclick");
      }
    }
