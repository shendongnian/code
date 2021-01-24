    public class RootObject
    {
        public string target { get; set; }
        public string lastseen { get; set; }
    }
    
    restClient = new RestClient();
    
    restRequest = new RestRequest(ApiUrl, Method.POST, DataFormat.Json);
    
    RootObject myObject = new RootObject();
    myObject.target = "[5,5]";
    myObject.lastseen = "1555459984";
    var json = JsonConvert.SerializeObject(myObject);
    
    restRequest.AddParameter("application/json", ParameterType.RequestBody);
    
    restRequest.AddJsonBody(json);
