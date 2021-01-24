    var requestUrl = $"{graphClient.BaseUrl}/applications/{id}/requiredResourceAccess";
    var message = new HttpRequestMessage(HttpMethod.Get, requestUrl);
    await graphClient.AuthenticationProvider.AuthenticateRequestAsync(message);
    var response = await graphClient.HttpProvider.SendAsync(message);
    var content = await response.Content.ReadAsStringAsync();
    var resourceAccesses = JsonConvert.DeserializeObject<List<RequiredResourceAccess>>(JObject.Parse(content)["value"].ToString());
