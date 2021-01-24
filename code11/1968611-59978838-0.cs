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
