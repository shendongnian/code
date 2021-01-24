    public static class FunctionForController
        {
            [FunctionName("FunctionForController")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
            {
                log.Info("C# HTTP trigger function processed a request.");
    
                // parse query parameter
                string name = req.GetQueryNameValuePairs()
                    .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                    .Value;
    
                if (name == null)
                {
                    // Get request body
                    dynamic data = await req.Content.ReadAsAsync<object>();
                    name = data?.name;
                }
    
                ContactInformation objContact = new ContactInformation();
    
                objContact.Name = "From Azure Function";
                objContact.Email = "fromazure@function.com";
    
                return req.CreateResponse(HttpStatusCode.OK, objContact);
            }
        }
