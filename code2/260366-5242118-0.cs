    Exception ex = Server.GetLastError();
    if (ex != null)
    {
        HttpException hex = ex;
        if (hex != null)
            Session["Ex"] = hex; // try to do something else instead of accessing session
    }
    Session["Ex_T"] = ex; // try to do something else instead of accessing session
    Response.Redirect("~/errorPage.aspx" );
