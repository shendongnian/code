       public class CustomResult<T> : IHttpActionResult
        {
    
            private readonly HttpRequestMessage _request;
            private readonly T _content;
    
    
            public CustomResult(HttpRequestMessage request, T content)
            {
                _request = request;
                _content = content;
            }
            
            public CustomResult(HttpRequestMessage request)
            {
                _request = request;
            }
    
            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
         
                if (_content==null)
                {
                     var response =_request.CreateResponse(HttpStatusCode.NoContent, JsonMediaTypeFormatter.DefaultMediaType);
                }else
                {
                   var jsonData = JsonConvert.SerializeObject(_content, _content.GetType(), new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        Formatting = Formatting.Indented
                    });
                            var response = _request.CreateResponse(HttpStatusCode.OK, jsonData, JsonMediaTypeFormatter.DefaultMediaType);
                            response.Content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                }   
                return Task.FromResult(response);
            }
        }
