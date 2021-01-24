     [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var url = "https://api.plos.org/search?q=title:DNA";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var httpClient = new HttpClient();
            using (var response = await httpClient.SendAsync(request))
            {
                var content = response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return Ok(content);
            }
        }
