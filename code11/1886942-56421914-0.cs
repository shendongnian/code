var objRequest = new CustomerDetailsRequest() {
    customerId = 1
};
string url = $"/api/v1/CustomerDetails";
var requestBody = await Task.Run(() => JsonConvert.SerializeObject(objRequest));
using (var httpClient = new HttpClient())
{
    CustomerDetailsResponse data = new CustomerDetailsResponse();
    try
    {
        httpClient.BaseAddress = new Uri("http://localhost:3000");
        var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
        var result = await httpClient.PostAsync(url, content);
        var response = await result.Content.ReadAsStringAsync();
        data = JsonConvert.DeserializeObject<CustomerDetailsResponse>(response);
        if (result.IsSuccessStatusCode && result.StatusCode == HttpStatusCode.OK)
        {
            return data;
        }
        return null;
    }
    catch (Exception exp)
    {
        return null;
    }
}
Let me know if this is confusing
