      protected void Page_Error(object sender, EventArgs e) {
        var ex = Server.GetLastError().GetBaseException();
    
        Response.StatusCode = 500;
        Response.Redirect("~/SubError.aspx", true);
      }
