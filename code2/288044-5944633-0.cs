    protected void ScriptManager1_AsyncPostBackError(object sender, 
        AsyncPostBackErrorEventArgs e)
    {
        ScriptManager1.AsyncPostBackErrorMessage = e.Exception.Message;
        Server.ClearError();
        Response.StatusCode = 500;
    }
