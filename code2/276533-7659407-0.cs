    public Service(): base()
    {
        if (!GetUser().LoggedIn)
        {
            Context.Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
            Context.Response.End();
        }
    }
