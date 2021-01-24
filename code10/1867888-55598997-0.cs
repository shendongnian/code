    protected void Page_Error(object sender, EventArgs e)
        {
            Response.Clear();
            Exception ex = Server.GetLastError();
            Response.Write("Something not yet");
            Response.Write(ex.Message);
            Server.ClearError();
        }
