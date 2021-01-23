    private void PurgeSession()
    {
        try
        {
            Session.Clear();
        }
        catch (Exception) {  }
        try
        {
            Session.Abandon();
        }
        catch (Exception) {  }
        try
        {
            Session.RemoveAll();
        }
        catch (Exception) {  }
        try
        {
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId") 
                                    {Expires = DateTime.Now.AddYears(-1)});
        }
        catch (Exception) {  }
    }
