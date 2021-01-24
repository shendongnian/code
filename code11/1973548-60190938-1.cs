    [Test]
    public async Task RunARoute_Should_Redirect() {
        var response = await _client.GetAsync("/foo");
        CheckThat(response.StatusCode).Is(HttpStatusCode.Found); //302 Found
        var redirectUrl = response.Headers.Location;
        //assert expected redirect URL
        //...
        response = await _client.GetAsync(redirectUrl);       
        Check.That(response.IsSuccessStatusCode).IsTrue(); //200 OK
    }
