      public class Monthly
        {
            public string Year { get; set; }
            public string Month { get; set; }
            public string  Hh { get; set; }
        }
    var contentJson = await SendRequest(request);
    dynamic response = JsonConvert.DeserializeObject(contentJson); 
    List<Monthly> organizations = response.organizations.ToObject<List<Monthly>>();
