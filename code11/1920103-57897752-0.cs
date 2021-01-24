    [HttpPost]
    [Route("api/Controller/IncomingPO")]
    public HttpResponseMessage IncomingPO(HttpRequestMessage request)
    {
      //do some stuff
      return new HttpResponseMessage()
                {
                    Content = new StringContent("My response string", System.Text.Encoding.UTF8, "application/xml"),
                    StatusCode = HttpStatusCode.OK
                };
    }
