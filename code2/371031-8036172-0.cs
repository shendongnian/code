    if(Session["CurrentUrl"] != null)
    {
      var ip = new Uri(Session["CurrentUrl"]);
      var ipNoPort = string.Format("{0}://{1}/{2}", ip.Scheme, ip.Host, ip.PathAndQuery);
      return Redirect(ipNoPort);
    }
    
    return Home();
