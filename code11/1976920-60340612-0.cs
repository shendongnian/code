var body = new { 
    authenticate = new Authenticate() { 
        userLogin = login, 
        authenticateKey = pass} 
    },
    @params = new OrdersGet() {
        orderPrepaidStatus = orderPrepaidStatus
    }
}
// Adds the entire object to the request
// after serializing it and making it json
restRequest.AddJsonBody(body);
// Executes the request with the proper payload
IRestResponse restResponse = restClient.Execute(restRequest);
Console.WriteLine("Status: " + restResponse.StatusCode);
Console.WriteLine("\nResponse: " + restResponse.Content);
Console.WriteLine("\nRequest: " + body.ToString());
