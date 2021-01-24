    [Test]
    public async Task RunARoute_Should_Redirect() {        
        _server.PreserveExecutionContext = true;
        var client = _server.CreateClient();
        var response = await _client.GetAsync("/foo");
        Check.That(response.StatusCode).IsEqualTo(HttpStatusCode.Found); //302 Found
        var redirectUrl = response.Headers.Location;
        //assert expected redirect URL
        //...
        response = await _client.GetAsync(redirectUrl);       
        Check.That(response.IsSuccessStatusCode).IsTrue(); //200 OK
    }
