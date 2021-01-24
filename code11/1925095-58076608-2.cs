        internal async Task<Attachement> UploadAttachment(string filename,byte[] content)
        {
            ByteArrayContent data = new ByteArrayContent(content);
            HttpClient client = GetApiClient();
            using (HttpResponseMessage response = await client.PostAsync($"https://dev.azure.com/{_org}/_apis/wit/attachments?fileName={filename}&api-version=5.1", data))
            {
                // Parse response body en evaluate result
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Attachement>(responseBody);
            }
        }
