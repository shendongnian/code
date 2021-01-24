    public ActionResult Index()
    {
    var client = new RestClient("https://blackboard.ddns.net/");
    
    var request = new RestRequest("/learn/api/public/v1/courses/uuid:d23e128e62f8483699c26836e06cab32/contents/_27_1/attachments/_13_1/download", Method.GET);           
    
    client.AddDefaultHeader("Authorization", "Bearer ZVAFzAuZ1ujYRENLrjNv3b8UWWvgRic4");
    
    var response = client.Execute(request);           
    
    return File(response.RawBytes, "text/plain", "MyTest.txt");
    
    }
