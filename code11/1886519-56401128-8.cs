    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        [Route("post")]
        public async Task<string> Post([FromBody]Credentials cred)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.elliemae.com/oauth2/");
                HttpRequestMessage request = new HttpRequestMessage
                (HttpMethod.Post, "v1/token")
                {
                    Content = new StringContent(new JavaScriptSerializer().Serialize(cred), Encoding.UTF8, "application/json")
                };
                HttpResponseMessage response = await client.SendAsync(request);
               string result = new JavaScriptSerializer().Serialize(response.Content);
               return result;
           }
        }
    }
