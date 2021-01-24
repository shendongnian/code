    public JObject ExecuteJson<T>(string requestUri, HttpMethod method, IDictionary<string, string> headers, T payload)
            {
                HttpResponseMessage response;
                switch (method.Method)
                {
                    case "POST":
                        var requestContent = new StringContent(JsonConvert.SerializeObject(payload));
                        requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");
                        var Digest = RequestFormDigest();
                        DefaultRequestHeaders.Clear();
                        DefaultRequestHeaders.Add("X-RequestDigest", Digest);
                        if (headers != null)
                        {
                            foreach (var header in headers)
                            {
                                DefaultRequestHeaders.Add(header.Key, header.Value);
                            }
                        }
                        response = PostAsync(requestUri, requestContent).Result;
                        break;
                    case "GET":
                        response = GetAsync(requestUri).Result;
                        break;
                    default:
                        throw new NotSupportedException(string.Format("Method {0} is not supported", method.Method));
                }
    
                response.EnsureSuccessStatusCode();
                var responseContent = response.Content.ReadAsStringAsync().Result;
                return String.IsNullOrEmpty(responseContent) ? new JObject() : JObject.Parse(responseContent);
            }
