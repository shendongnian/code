    var client = new RestClient("http://example.com");
    
    var request = new RestRequest("resource/{id}", Method.POST);
    request.AddParameter("username", txtUsername.Text); // adds to POST or URL querystring based on Method
    request.AddParameter("password", txtPassword.Text); // adds to POST or URL querystring based on Method
    // execute the request
    RestResponse response = client.Execute(request);
    var content = response.Content; // raw content as string
