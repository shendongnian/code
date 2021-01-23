    HttpWebRequest Request = WebRequest.Create(Url) as HttpWebRequest;
    Request.Method = "GET"; //Or PUT, DELETE, POST
    Request.ContentType = "application/x-www-form-urlencoded";
    using (HttpWebResponse Response = Request.GetResponse() as HttpWebResponse)
    {
       if (Response.StatusCode != HttpStatusCode.OK)
          throw new Exception("The request did not complete successfully and returned status code " + Response.StatusCode);
       using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
       {
          string ReturnedData=Reader.ReadToEnd();
       }
    }
