    private async Task<KeyValuePair<HttpResponseMessage, T>> SendRequestAsync<T, U>(string requestUri, U content, HttpMethod method, AuthenticationHeaderValue authHeader = null, Dictionary<string, string> headers = null)
    {
        using (HttpRequestMessage request = new HttpRequestMessage())
        {
            request.Method = method;
            request.RequestUri = new Uri(requestUri, UriKind.Absolute);
    
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            if (authHeader != null)
            {
                request.Headers.Authorization = authHeader;
            }
    
            string requestContent = null;
    
            if (content != null)
            {
                requestContent = JsonConvert.SerializeObject(content);
                request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");
            }
    
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    if (!request.Headers.Contains(header.Key))
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
            }
            
            // _client would be a private implementation or injected version of your httpclient
            using (HttpResponseMessage response = await _client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null)
                    {
                        var rawJson = await response.Content.ReadAsStringAsync();
    
                        var mappedObj = JsonConvert.DeserializeObject<T>(rawJson);
    
                        var result = new KeyValuePair<HttpResponseMessage, T>(response, mappedObj);
    
                        return result;
                    }
                }
                else
                {
                    // do something else
                }
    
                return new KeyValuePair<HttpResponseMessage, T>(response, default(T));
            }
        }
    }
