    foreach (Process p in Process.GetProcessesByName("WebDev.WebServer"))
    {
        Response.Write(DateTime.Now.Subtract(p.StartTime).ToString() + "<br/>");
    }
    
    Response.Write(DateTime.Now.Subtract((DateTime)Application["StartTime"]).ToString());
