    using(var httpClient = new HttpClient()) {
     httpClient.SetBearerToken(tokenValue);
     var serData = JsonConvert.SerializeObject(modelData);
     var httpRequestContentData = new StringContent(serData, Encoding.UTF8, "application/json");
     using(var result = httpClient.PostAsync(url, httpRequestContentData).Result) {
      if ((int) result.StatusCode == (int) HttpStatusCode.OK) {
       // Go Ahead 
      }
    
     }
    }
