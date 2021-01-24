using (var httpClient = new HttpClient())
{
    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.tink.com/api/v1/oauth/token"))
    {
        var contentList = new List<string>();
        contentList.Add("code=1a513b99126ade1e7718135019fd119a");
        contentList.Add("client_id=YOUR_CLIENT_ID");
        contentList.Add("client_secret=YOUR_CLIENT_SECRET");
        contentList.Add("grant_type=authorization_code");
        request.Content = new StringContent(string.Join("&", contentList));
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded"); 
        var response = await httpClient.SendAsync(request);
    }
}
The 401 headers you are getting back may be due to passing in the wrong id and secret, I presume there is a way for you to get test credentials.
