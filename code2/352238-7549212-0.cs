    [System.Web.Services.WebMethod(EnableSession=true)]
    public string Bla(double bla)
    {
       //code here
       var test = HttpContext.Current.Session["test"];
    }
  
