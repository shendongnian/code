client.BaseAddress = new Uri("https://sandbox-quickbooks.api.intuit.com/v3/company/1232/vendor/70?minorversion=8");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));
client.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("Bearer", "bLpuw.vjbvIP_P7Vyj4ziSGa3Ohg");
var postContent = new StringContent("myContent");
using (HttpResponseMessage response = client.PostAsync("https://sandbox-quickbooks.api.intuit.com/v3/company/1232/query?minorversion=8", postContent).Result)
{
    using (HttpContent content = response.Content)
    {
        var json = content.ReadAsStringAsync().Result;
    }
}
Also, please be aware that you have some wrong use of the Async methods, you should always await instead of using the blocking `Result` property from the task.
