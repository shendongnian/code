    string domain2 = Request.RawUrl.Replace("domain1.com","domain2.com");
    try
    {
      // *** Establish the request
      HttpWebRequest loHttp = (HttpWebRequest)WebRequest.Create(domain2);
    
      // *** Set properties
      loHttp.Timeout = 10000;     // 10 secs
    
      // Retrieve request info headers 
      HttpWebResponse loWebResponse = (HttpWebResponse)loHttp.GetResponse();
    
      loWebResponse.Close();
      Response.Redirect(domain2);    //Page is valid..redirect to it.
    }
    catch ( WebException ex )
    {
      if ( ex.Status.Message.Contains("404") )
         Response.Redirect("www.domain2.com"   //Redirect to front page since page doesn't exists
      
    }
