	[Route("files/")]
    [HttpGet]
    public async Task<string> GetFileInfo(string fileName, string access_token)
    {
        using (WebClient client = new WebClient())
        {
            var host = $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Host}:{HttpContext.Current.Request.Url.Port}";
            var data = client.DownloadString($"{host}/proxy/files/?fileName={HttpUtility.UrlEncode(fileName)}&access_token={HttpUtility.UrlEncode(access_token)}");
            return data;
        }
    }
    [AllowAnonymous]
    [Route("proxy/files/")]
    [HttpGet]
    public async Task<string> ProxyGetFileInfo(string fileName, string access_token)
    {
        return "MyValues";
    }
