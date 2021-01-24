    HttpClient client = new HttpClient(handler);
    
                **var byteArray = Encoding.ASCII.GetBytes("username:password1234");**
            
    **client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));**
