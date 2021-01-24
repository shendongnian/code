        private HttpResponseMessage Post(string url, string requestUri, object content)
        {
            string serialized = JsonConvert.SerializeObject(content);
            StringContent stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = Task.Run(() => client.PostAsync(requestUri, stringContent)).Result;
            client.Dispose();
            return response;
        }
