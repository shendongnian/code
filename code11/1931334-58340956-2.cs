        // Create a new NameValueCollection instance to hold some custom 
        // parameters to be posted to the URL.
          NameValueCollection myNameValueCollection = new NameValueCollection();
          myNameValueCollection.Add("plu_str",postdata);        
         using(WebClient myWebClient = new WebClient())
         {
           myWebClient.Headers.Add("X-API-KEY",APIKEY);
           myWebClient.Headers.Add("Content-Type","application/x-www-form-urlencoded");
           //UploadData implicitly sets HTTP POST as the request method.
          byte[] responseArray = myWebClient.UploadValues("http://testapi.com",myNameValueCollection);
           
          var result = Encoding.UTF8.GetString(responseArray);
         }
