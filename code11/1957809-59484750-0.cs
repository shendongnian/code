    public async Task<Category> PostCategoryAsync(Uri requestUrl, CategoryViewModel content)
        {
            addHeaders();
            var response = new HttpResponseMessage();
            var fileContent = new StreamContent(content.Files.OpenReadStream())
            {
                Headers =
                {
                    ContentLength = content.Files.Length,
                    ContentType = new MediaTypeHeaderValue(content.Files.ContentType)
                }
            };
            var formDataContent = new MultipartFormDataContent();
            formDataContent.Add(fileContent, "Files", content.Files.FileName);          // file
            //other form inputs
            formDataContent.Add(new StringContent(content.Name), "Name");   
            formDataContent.Add(new StringContent(content.Brief), "Brief");   
            formDataContent.Add(new StringContent(content.IsDraft.ToString()), "IsDraft");   
            formDataContent.Add(new StringContent(content.Color), "Color");  
            formDataContent.Add(new StringContent(content.Priority), "Priority");   
            response = await _httpClient.PostAsync(requestUrl.ToString(), formDataContent);
            var data = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<Category>(data);
        }
