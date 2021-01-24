    static Lazy<HttpClient> client = new Lazy<HttpClient>();
    const string WebCamUrl = "http://mywebcam/livrestream.cgi";
    [Route("api/test")]
    [HttpGet]
    public async Task<IActionResult> Test() {
        var proxyRequest = new HttpRequestMessage(HttpMethod.Get, WebCamUrl);
        //Check is video client sent range headers and pass them along
        RequestHeaders httpRequestHeaders = Request.GetTypedHeaders();
        RangeHeaderValue rangeHeader = httpRequestHeaders.Range;
        if (rangeHeader != null) {
            proxyRequest.Headers.Range = rangeHeader;
        }
        HttpResponseMessage response = await client.Value.SendAsync(proxyRequest);
        HttpContent content = response.Content;
        var contentType = content.Headers.ContentType;
        Stream sourceStream = await content.ReadAsStreamAsync();
        return File(sourceStream, contentType: contentType.ToString(), enableRangeProcessing: true);
    }
