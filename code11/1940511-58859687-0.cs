    GitAnnotatedTag tag = null;
            try
            {
                var tagObject = new { Name = tagName.Replace(' ', '_'), Message = tagComment, TaggedObjectId = commitId };
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(tagObject),
                    Encoding.UTF8,
                    "application/json");
                client.DefaultRequestHeaders.Add("Accept", "application/json; charset=utf-8; api-version=3.2-preview.1");
                using (HttpResponseMessage response = client.PostAsync(string.Format(createTagUrl, projectId, repositoryId), stringContent).Result)
                {
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();                    
                    tag = JsonConvert.DeserializeObject<GitAnnotatedTag>(responseBody);
                }
            }
            catch (Exception ex)
            {
                // Add some error handling here
            }
            return tag;
