    if(String.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables("HTTP_X_FORWARDED_FOR"))) {
       string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    }
    else {
       string ipAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
    
    }
