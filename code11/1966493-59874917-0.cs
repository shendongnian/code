    public class InvokeAzureFunctionController : ApiController
        {
            // GET api/<controller>
            public async System.Threading.Tasks.Task<IEnumerable<object>> GetAsync()
            {
                HttpClient _client = new HttpClient();
                HttpRequestMessage newRequest = new HttpRequestMessage(HttpMethod.Get, "http://localhost:7071/api/FunctionForController");
                HttpResponseMessage response = await _client.SendAsync(newRequest);
    
                dynamic responseResutls = await response.Content.ReadAsAsync<dynamic>();
                return responseResutls;
            }
    	}
