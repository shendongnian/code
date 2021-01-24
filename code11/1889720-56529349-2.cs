    namespace APICredential.Controllers
{
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        [HttpGet, Route("values")]
        public async Task<string> Post()
        {
            Credentials cred = new Credentials()
            {
                username = "admin@encompass:BE11200822",
                password = "Shmmarch18",
                grant_type = "passwordusername",
                client_id = "gpq4sdh",
                client_secret = "secret",
                scope = "lp"
            };
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://api.elliemae.com/oauth2/");
                var parameters = new Dictionary<string, string>()
    {
        {"username", "admin@encompass:BE11200822"},
        {"password ", "Shmmarch18"},
        {"grant_type", "password"}, //Gran_type Identified here
        {"client_id", "gpq4sdh"},
        {"client_secret", "dcZ42Ps0lyU0XRgpDyg0yXxxXVm9@A5Z4ICK3NUN&DgzR7G2tCOW6VC#HVoZPBwU"},
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
