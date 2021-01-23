HomeController.cs
    public ActionResult Index(string languageCode)
    {
       if (string.IsNullOrEmpty(languageCode) ||
          languageCode != a valid language code)
       {
           // No code was provided OR we didn't receive a valid code 
           // which you can't handle... so send them to a 404 page.
           // return ResourceNotFound View ...
       }
    
       // .. do whatever in here ..
    }
