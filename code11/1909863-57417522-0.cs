            var httpClientHandler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential(username, password, domainName),
            };
            var httpClient = new HttpClient(httpClientHandler);
            // This is 10 seconds.
            httpClient.Timeout = new TimeSpan(100000000);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // Serialize the object
            var serializedItem = new StringContent(
                JsonConvert.SerializeObject(myUnserializedObject),
                Encoding.UTF8, 
                "application/json");
            var result = await httpClient.PostAsync(url, serializedItem);
