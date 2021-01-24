    public async Task<IHttpActionResult> PostProductId(string path)
    {
        using (var client = GetHttpClient())
        {
            string content = null;
            try
            {
                string endpoint = path;
    
                string requestJson = JsonConvert.SerializeObject(bodyObject);
                HttpContent httpContent = new StringContent(requestJson, Encoding.UTF8, "application/json");
    
                var response = await client.PostAsync(endpoint, httpContent);
    
                content = response.Content.ReadAsStringAsync();
    
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                return InternalServerError(ex);
            }
            return Ok(content);
        }
    }
