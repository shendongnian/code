    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        object o = context.Session["counter"];
        if (o == null)
            context.Session["counter"] = 1;
        else
            context.Session["counter"] = ((int) o) + 1;
        context.Response.Write(context.Session.SessionID + "\r\n");
        context.Response.Write(context.Session["counter"]);
    }
