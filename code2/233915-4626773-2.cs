    using System.Web;
    using System.Text;
    using System.Web.UI;
    /// 
    /// A JavaScript alert
    /// 
    public static class Alert
    {
        /// 
        /// Shows a client-side JavaScript alert in the browser.
        /// 
        /// The message to appear in the alert.
        public static void Show(string message)
        {
           // Cleans the message to allow single quotation marks
           string cleanMessage = message.Replace("'", "\\'");
           string script = "alert('" + cleanMessage + "');";
           // Gets the executing web page
           Page page = HttpContext.Current.CurrentHandler as Page;
           // Checks if the handler is a Page and that the script isn't allready on the Page
           if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
           {
             page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", script);
           }
        }
    }
