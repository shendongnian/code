    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
          {
            return base.SendAsync(request, cancellationToken)
                .ContinueWith<HttpResponseMessage>(task =>
                   {
                    var response = task.Result;
    
                    if (CheckIfRequestHadSuppressStatusCode(request) == true)
                      {
                       switch(response.Content.Headers.ContentType.MediaType) {
                         case "application/xml":
                            response.Content = new XmlWithStatusContent(response.Content)
                            break;
                         case "application/json":
                            response.Content = new JsonWithStatusContent(response.Content)
                            break;
                      }
                    
                      response.StatusCode = HttpStatusCode.OK;                                 
                    }
    
            return response; });
