     byte[] data = Encoding.UTF8.GetBytes(postdata);
     using(WebClient myWebClient = new WebClient())
     {
       myWebClient.Headers.Add("X-API-KEY",APIKEY);
       myWebClient.Headers.Add("Content-Type","application/x-www-form-urlencoded");
       //UploadData implicitly sets HTTP POST as the request method.
      byte[] responseArray = myWebClient.UploadData("http://testapi.com",data);
       
      var result = Encoding.UTF8.GetString(responseArray);
     }
