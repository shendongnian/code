        public static async Task<string> DownloadPageAsync(string url)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler { UseDefaultCredentials = true, AllowAutoRedirect = true };
                HttpClient client = new HttpClient(handler);
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string html = await response.Content.ReadAsStringAsync();
                return html;
            }
            catch (Exception)
            {
                return "";
            }
        }
