    public static void SendAlert(string sMessage)
    {
        sMessage = "alert('" + sMessage.Replace("'", @"\'").Replace("\n", @"\n") + "');";
        if (HttpContext.Current.CurrentHandler is Page)
        {
            Page p = (Page)HttpContext.Current.CurrentHandler;
            if (ScriptManager.GetCurrent(p) != null)
            {
                ScriptManager.RegisterStartupScript(p, typeof(Page), "Message", sMessage, true);
            }
            else
            {
                p.ClientScript.RegisterStartupScript(typeof(Page), "Message", sMessage, true);
            }
        }
    }
