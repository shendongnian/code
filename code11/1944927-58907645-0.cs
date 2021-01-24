requestMessage.Headers["Authorization"] = "Basic " + 
    Convert.ToBase64String(Encoding.ASCII.GetBytes("username:password"));
The grant type needs to be sent as content.
var content = new FormUrlEncodedContent(new[]
{
    new KeyValuePair<string, string>("grant_type", "client_credentials")
});
var result = await client.PostAsync(url, content);
You could also try sending username and password in the body.
using (HttpClient client = new HttpClient())
{
	var req = new HttpRequestMessage(HttpMethod.Post, new Uri(url));
	req.Content = new FormUrlEncodedContent(new Dictionary<string, string>
	{
		{ "grant_type", "client_credentials" }, // or "password"
		{ "username", username },
		{ "password", password }
	});
	var response = await client.SendAsync(req);
	// No error handling for brevity
	var data = await response.Content.ReadAsStringAsync();
Finally you may or may not need to set the accept header.
request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
