    HttpResponseMessage responseMessage = new HttpResponseMessage()
    {
          Content = new StringContent(JsonConvert.SerializeObject(message)),
          //StatusCode = System.Net.HttpStatusCode.Forbidden
          StatusCode = System.Net.HttpStatusCode.Unauthorized
    };
   
