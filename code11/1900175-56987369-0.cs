[HttpPost] // OWIN - Open Web Interface for .NET
public HttpResponseMessage Post([FromBody] long timeTaken)
{
      _api.DataBuilder.NumberOfAPICalls += 1;
      _api.DataBuilder.ResponseTimes.Add(timeTaken);
      return Request.CreateResponse(HttpStatusCode.OK); //Using Post Method
}
