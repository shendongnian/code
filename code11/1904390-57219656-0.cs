            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, string.Format("Companies?aCompanyName={0}", aCompanyName));
            using HttpResponseMessage response = await Client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode == false)
            {
                throw new ApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = content
                };
            }
            _JsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<IEnumerable<Company>> (content, _JsonOptions);
