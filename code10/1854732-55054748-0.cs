    // uses Newtonsoft.Json
    var serializedString = JsonConvert.SerializeObject(yourObject);
    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized)
    {
        Content = new StringContent(serializedString, System.Text.Encoding.UTF8, "application/json"),
        ReasonPhrase = msg
    });
