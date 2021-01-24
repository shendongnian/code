    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        // POST api/values
        [HttpPost, Route("values")]
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
                //for now, see what response gets you and adjust your code to return the object you need, if the api is returning a serialized json string.. then we can return a string here... like so
               string result = await response.Content.ReadAsStringAsync();
               return result;
           }
        }
    }
