       string DataBoundary = "-----------------------------" + DateTime.Now.Ticks.ToString("x"); 
        string contentType = "multipart/form-data; boundary=" + DataBoundary ;
        req.Method = "POST";
        req.ContentType = contentType ;
        req.UserAgent = userAgent;
        req.CookieContainer = new CookieContainer();
        req.ContentLength = formData.Length;
