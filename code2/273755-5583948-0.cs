        // Let the object fill itself 
        // with the parameters of the current page.
        var qs = System.Web.HttpUtility.ParseQueryString(Request.RawUrl);
     
        // Read a parameter from the QueryString object.
        string value1 = qs["name1"];
      
        // Write a value into the QueryString object.
        qs["name1"] = "This is a value";
  
    
   
