     [System.Web.Services.WebMethod(EnableSession=true)]
        public static string Bla(double bla)
        {
           //code here
           var test = HttpContext.Current.Session["test"];
    
        }
  
