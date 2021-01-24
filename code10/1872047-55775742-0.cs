    private Task<object> PostAsync<T1, T2>(string uri, T2 content)
    {
        return PostAsync<T1, T2>(uri, content, new DefaultNamingStrategy());
    }
    private async Task<object> PostAsync<T1, T2>(string uri, T2 content, NamingStragy namingStrategy)
    {
        using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri))
        {
            var json = JsonConvert.SerializeObject(content);
            using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                requestMessage.Content = stringContent;
    
                HttpResponseMessage response = await _client.SendAsync(requestMessage);
                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation("Request Succeeded");
    
                    var deserializerSettings = new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver
                        {
                            NamingStrategy = namingStrategy
                        }
                    };
                    T1 responseModel = JsonConvert.DeserializeObject<T1>(await response.Content.ReadAsStringAsync(), deserializerSettings);
                    return responseModel;
                }
                else
                {
                    return await GetFailureResponseModel(response);
    
                }
            }
        }
    }
