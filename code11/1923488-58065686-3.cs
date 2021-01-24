    static Lazy<HttpClient> client = new Lazy<HttpClient>();
    const string WebCamUrl = "http://mywebcam/livrestream.cgi";
    [Route("api/test")]
    [HttpGet]
    public async Task<IActionResult> Test() {        
        var contentType = "multipart/x-mixed-replace;boundary=myboundary";
        Stream stream = await client.Value.GetStreamAsync(WebCamUrl);
        var result = new FileStreamResult(stream, contentType) {
             EnableRangeProcessing = true
        };
        return result;
    }
