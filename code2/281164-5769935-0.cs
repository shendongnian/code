    if(e.CommandName == "StoreValue")
    {
      GridViewRow row = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
      string title = row.Cells[ColumnIndex].Text;
        Session["Title"] = title;
        Response.Redirect("RateBook.aspx");
    }
