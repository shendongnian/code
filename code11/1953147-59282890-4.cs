            using var client = new HttpClient(); // init client
            // set headers
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", Convert.ToBase64String(
                    System.Text.Encoding.ASCII.GetBytes(
                        $"{username}:{password}"))); 
            client.DefaultRequestHeaders.Add("aw-tenant-code", $"{key}");
            // generate list of requests
            var list = new List<Task<HttpResponseMessage>>();
            for (int i = 0; i < 10; i++) // count of parallel requests or other GET requests
            {
                // add requests to the list of tasks
                list.Add(client.GetAsync("https://www.google.com/"));
            }
            // all requests finished
            await Task.WhenAll(list);
            foreach (var task in list)
            {
                // get result per each request
                var result = await task;
            }
   
