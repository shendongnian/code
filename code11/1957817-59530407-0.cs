     using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://XXX.atlassian.net/rest/api/2/issue/TST-4/transitions?expand=transitions.fields"))
                    {
                        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("user:token"));
                        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");
    
                        request.Content = new StringContent("{\"transition\":{\"id\":\"31\"}}");
                        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    
                        var response = await httpClient.SendAsync(request);
                    }
                }
