    var c = new HttpValueCollection(); 
    c.Add(HttpUtility.ParseQueryString(Request.Url.Query)); 
     
    if (!string.IsNullOrEmpty(c["PID"])) 
        c.Remove("PID"); 
