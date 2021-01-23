    If( Session["Login-user"] != null && Session["Login-user"].ToString().Length > 0 ) {
        // Login OK
    }
    else {
        // Login Not OK, redirect
        Response.Redirect("~/Login.aspx");
    }
