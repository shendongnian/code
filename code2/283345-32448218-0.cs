    /// <summary>
    /// A JavaScript alert class
    /// </summary>
    public static class webMessageBox
    {
    
    /// <summary>
    /// Shows a client-side JavaScript alert in the browser.
    /// </summary>
    /// <param name="message">The message to appear in the alert.</param>
        public static void Show(string message)
        {
           // Cleans the message to allow single quotation marks
           string cleanMessage = message.Replace("'", "\\'");
           string wsScript = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
    
           // Gets the executing web page
           Page page = HttpContext.Current.CurrentHandler as Page;
    
           // Checks if the handler is a Page and that the script isn't allready on the Page
           if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
           {
               //ClientScript.RegisterStartupScript(this.GetType(), "MessageBox", wsScript, true);
               page.ClientScript.RegisterClientScriptBlock(typeof(webMessageBox), "alert", wsScript, false);
           }
        }    
    }
