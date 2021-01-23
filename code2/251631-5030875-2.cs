    protected void Application_Error(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        var exception = context.Server.GetLastError();
        if (exception is HttpRequestValidationException)
        {
            context.Server.ClearError();    // Here is the new line.
            Response.Clear();
            Response.StatusCode = 200;
            Response.Write(@"<html><head></head><body>hello</body></html>");
            Response.End();
            return;
        }
    }
