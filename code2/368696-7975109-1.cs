    using System;
    using System.Web.Services;
    
    public partial class _Default : System.Web.UI.Page
    {
        [WebMethod]
        public static string GetDate(string fromDate, string toDate)
        {
            DateTime dtFromDate;
            DateTime dtToDate;
    
            // Try to parse the dates
            if (DateTime.TryParse(fromDate, out dtFromDate) &&
                DateTime.TryParse(toDate, out dtToDate))
            {
                // Perform calculation and/or database query
    
                return "success!";
            }
    
            return null;
        }
    }
