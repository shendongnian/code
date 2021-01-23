    // Convert Object to JSON
    var requestMessage = JsonConvert.SerializeObject(requestObject);
    var content = new StringContent(requestMessage, Encoding.UTF8, "application/json");
    // Create the Client
    var client = new HttpClient();
    client.DefaultRequestHeaders.Add(AuthKey, AuthValue);
    // Post the JSON
    var responseMessage = client.PostAsync(requestEndPoint, content).Result;
    var stringResult = responseMessage.Content.ReadAsStringAsync().Result;
    // Convert JSON back to the Object
    var responseObject = JsonConvert.DeserializeObject<ResponseObject>(stringResult);
