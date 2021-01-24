public void SetContent<TEntity>(TEntity input)
        {
            var json = JsonConvert.SerializeObject(input);
            if (Request.Method == HttpMethod.Post|| Request.Method == HttpMethod.Put)
            {
                if (string.IsNullOrEmpty(ContentType) || ContentType == "application/json")
                {
                    Request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                else
                {
                    var parameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(json)
                                                .Concat(CustomParameters)
                                                .Where(p => !string.IsNullOrEmpty(p.Value));
                    Request.Content = new FormUrlEncodedContent(parameters);
                }
            }
        }
        public Out GetResponse<TEntity, Out>(HttpClient client, TEntity input)
        {
            var response = client.SendAsync(Request).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            SetHttpClientDataToEntity(input, response);
            if (!response.IsSuccessStatusCode)
            {
                ErrorDetail error;
                throw content.TryParseJson(out error)
                            ? new Exception(error.Message)
                            : throw new Exception(content);
            }
            Out result;
            content.TryParseJson<Out>(out result);
            return result;
        }
