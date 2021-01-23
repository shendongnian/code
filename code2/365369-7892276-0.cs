    if(HttpContext.Current.User.Identity != null)
    {
       string username = HttpContext.Current.User.Identity.Name.ToString();
       //rest of your code...
    }
