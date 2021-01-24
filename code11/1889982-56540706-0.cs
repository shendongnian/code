       using (HttpClient client = new HttpClient())
       {
          try	
          {
             string responseBody = await client.GetStringAsync(uri);
             var data = JsonConvert.DeserializeObject<RootObject>(responseBody);         
          }  
          catch(HttpRequestException e)
          {
              //log exception
          }
       }
 
