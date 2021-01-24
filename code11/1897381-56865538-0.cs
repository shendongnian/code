    protected async System.Threading.Tasks.Task<HttpResponseMessage> curlRequestAsync()
    {
        try
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "http://myurl.co.uk/rest/api/2/search?jql=assignee=bob"))
                {
                    var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("username:password"));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");
                    var result = await httpClient.SendAsync(request);
                    return result;
                }
            }
        }
        catch (Exception ex)
        {
             error.InnerText = ex.Message;
        }
    }
