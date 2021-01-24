        public async Task<bool> GetBooleanAsync()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var data = new { };
                var url = "my site url";
                var payload = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var req = await client.PostAsync(url, payload);
                var response = await req.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<bool>(response);
            }
        }
