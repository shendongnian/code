    Lazy<HttpClient> client = new Lazy<HttpClient>();
    [Route("api/test")]
    [HttpGet]
    public async Task<IActionResult> Test() {
        HttpResponseMessage response = await client.Value.GetAsync("http://mywebcam/livrestream.cgi");
        
        HttpContent content = response.Content;
        var contentType = content.Headers.ContentType;
        Stream sourceStream = await content.ReadAsStreamAsync();
        
        return File(sourceStream, contentType: contentType.ToString(), enableRangeProcessing: true);
    }
