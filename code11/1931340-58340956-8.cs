             Uri uri = new Uri("http://testapi.com");
             using(WebClient myWebClient = new WebClient())
             {
               myWebClient.Headers.Add("X-API-KEY",APIKEY);
               myWebClient.Headers.Add("Content-Type","application/x-www-form- urlencoded");
              
               string result = myWebClient.UploadString(uri ,"plu_str="+fileContents.ToString());
              }
