var authValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{login}:{password}")));
using (var client = new HttpClient() { DefaultRequestHeaders = { Authorization = authValue } })
{
	HttpResponseMessage response = client.PostAsync("https://localhost:44396/Documentation/All?pageNumber=0&pageSize=10", httpContent).Result;
	if (response.IsSuccessStatusCode)
	{
		response = await response.Content.ReadAsStringAsync();
	}
}
