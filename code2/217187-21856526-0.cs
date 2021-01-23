    void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex is HttpException && ((HttpException)ex).GetHttpCode() == 404)
        {
            Response.Redirect("~/filenotfound.aspx");
        }
        else
        {
            // your global error handling here!
        }
    }
