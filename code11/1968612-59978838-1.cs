public async Task<HttpResponseMessage> Test(string str)
{
    var httpClient = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Get, $"myAPI that returns different errors 400, 404, 500 etc based on str");
    var response = await httpClient.SendAsync(request);
    if (!response.IsSuccessStatusCode)
        return response;
    // do something else
    return new HttpResponseMessage(System.Net.HttpStatusCode.OK) { Content = new StringContent("Your Text here") };
}
***
>Other approach of using Filters
The other approach of using IHttpActionResult as your return type, you can use Filters to conform all your HttpResponseMessages to IHttpActionResult.
**Filter:** Create a separate cs file and use this filter definition.
public class CustomObjectResponse : IHttpActionResult
{
    private readonly object _obj;
    public CustomObjectResponse(object obj)
    {
        _obj = obj;
    }
    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        HttpResponseMessage response = _obj as HttpResponseMessage;
        return Task.FromResult(response);
    }
}
and in your API, you would use your filter like so,
public async Task<IHttpActionResult> Test(string str)
{
    var httpClient = new HttpClient();
    var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:4500/api/capacity/update-mnemonics/?mnemonic_to_update={str}");
    var response = await httpClient.SendAsync(request);
    if (!response.IsSuccessStatusCode)
        return new CustomObjectResponse(response);
    // Other Code here
    // Return Other objects 
    KeyValuePair<string, string> testClass = new KeyValuePair<string, string>("Sheldon", "Cooper" );
    return new OkWithObjectResult(testClass);
    // Or Return Standard HttpResponseMessage
    return Ok();
}
