    protected void MyGrid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      switch(e.CommandName)
      {
        case "SomeCommand":
          Response.Redirect("SomePage.aspx");
          break;
        case "OtherCommand":
          Respone.Redirect("OtherPage.aspx");
    }
