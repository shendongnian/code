    string endpoint = $"{Endpoint}/endpointName";
            string token_paramsJSON = JsonConvert.SerializeObject(v3Request.token_params, Formatting.Indented);
            Dictionary<string,string> PostParams = GetPOSTParams(v3Request);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, endpoint);
            
            UnicodeEncoding uniEncoding = new UnicodeEncoding();
            using (MultipartFormDataContent form = new MultipartFormDataContent())
            {
                foreach(var field in PostParams)
                {
                    StringContent content = new StringContent(field.Value);
                    content.Headers.ContentType = null;
                    form.Add(content, field.Key);
                }
                var JsonFile = new StringContent(token_paramsJSON);
                JsonFile.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                JsonFile.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "\"token_params\"",
                    FileName = "\"token.json\""
                };
                form.Add(JsonFile);
                request.Content = form;
                var response = await _httpClient.SendAsync(request, CancellationToken.None);
                return await GetCaptchaFromResponse(response);
            }
