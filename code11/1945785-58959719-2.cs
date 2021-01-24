    var json = JsonConvert.SerializeObject(new{ FieldA = "A", FieldB = "B" });
    var request = new HttpRequestMessage(new HttpMethod("POST"), "/api/some-endpoint")
    {
        Content = new StringContent(json, Encoding.UTF8)
    };
    //Changed this line. I think the previous line was the problem 'cause 
    // I saw a header duplication error in the stack trace referring to
    // the content type header, so overriding the header may have 
    // made the error gone
    request.Content.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Json);
    var client = httpClientFactory.CreateClient("my-client");
    var response = await client.SendAsync(request);
    var myResp = await response.Content.ReadAsAsync<MyResponse>();
