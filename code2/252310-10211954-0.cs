    void Application_Error(object sender, EventArgs e)
    {
        var serverError = Server.GetLastError() as HttpException;
        if (serverError != null)
        {
            if (serverError.GetHttpCode() == 404)
            {
                Server.ClearError();
                Response.Redirect("~/NotFound.aspx?URL=" + Request.Url.ToString());
            }
            Response.Redirect("~/Default.aspx");
        }
    }
