    namespace APICredential.Controllers
    {
        [RoutePrefix("api")]
        public class ValuesController : ApiController
        {
    
            [HttpGet, Route("values")]
            public async Task<string> Post()
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.elliemae.com/oauth2/");
    
    				/*
    				Credentials cred = new Credentials()
    				{
    
    					username = "username",
    					password = "password",
    					grant_type = "password",
    					client_id = "gpq4sdh",
    					client_secret = "secret",
    					scope = "lp"
    				};
    				*/
    
                    var parameters = new Dictionary<string, string>()
    				{
    					{"username", "admin@encompass:BE11200822"},
    					{"password ", "Shmmarch18"},
    					{"grant_type", "password"}, //Gran_type Identified here
    					{"client_id", "gpq4sdh"},
    					{"client_secret", "secret"},
    					{"scope", "lp"}
    				};
    
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "v1/token")
                    {
                        Content = new FormUrlEncodedContent(parameters)
                    };
    
                    HttpResponseMessage response = await client.SendAsync(request);
    
                    string result = await response.Content.ReadAsStringAsync();
    
                    return result;
                }
            }
        }
    }
