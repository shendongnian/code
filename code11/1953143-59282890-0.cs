            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        $"{username}:{password}")));
            client.DefaultRequestHeaders.Add("aw-tenant-code", $"{key}");
            var list = new List<Task<HttpResponseMessage>>();
            for (int i = 0; i < 10; i++) // count of parallel requests or other GET requests
            {
                list.Add(client.GetAsync("https://www.google.com/"));
            }
            await Task.WhenAll(list);
            foreach (var task in list)
            {
                var result = await task;
            }
   
