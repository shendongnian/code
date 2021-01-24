baseUrl = "http://localhost:1472/"; // change based on your domain setting
using (WebApp.Start<StartUp>(url: baseUrl))
{
     HttpClient client = new HttpClient();
     var resp = client.GetAsync(baseUrl).Result;
}
Here some changes in your code
var requestData = new List<KeyValuePair<string, string>>   // here 
{
       new KeyValuePair<string, string>( "Logging",timeTaken),
};
       Console.WriteLine("request data : " + requestData);
       FormUrlEncodedContent requestBody = newFormUrlEncodedContent(requestData);                
       var request = await client.PostAsync("here pass another server API", requestBody);
       var response = await request.Content.ReadAsStringAsync();
       Console.WriteLine("link response : " + response); 
Pls add your controller
[HttpPost] // OWIN - Open Web Interface for .NET
public HttpResponseMessage Post([FromBody] long timeTaken)
{
      _api.DataBuilder.NumberOfAPICalls += 1;
      _api.DataBuilder.ResponseTimes.Add(timeTaken);
      return Request.CreateResponse(HttpStatusCode.OK); //Using Post Method
}
