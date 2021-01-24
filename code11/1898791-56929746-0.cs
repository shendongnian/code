     var content = new StringContent(JsonConvert.SerializeObject(new object())); // send an empty object or a valid payload when needed
    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    var response = _client.PostAsync(url, content); // use send async instead 
    // then
    response.EnsureSuccessStatusCode();
    // or 
    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
