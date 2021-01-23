    protected void Application_Error()
    {
        Response.Clear();
        var ex = Server.GetLastError();
        if (ex is HttpException && 
            ex.Message.Contains("Unable to connect to SQL Server session database"))
        {
            Server.Transfer("/Maintenance.aspx");
        }
        else
        {
            Response.Write("Other error occurred.");
            Response.Write(ex.ToString());
            Response.End();
        }
    }
