    public static async Task<T> PostAsync<T>(object model, string url)
        {
            var resultStatus = false;
            T resultData = default(T);
            using (var client = new HttpClient(
                    new HttpClientHandler()
                    {
                        UseProxy = false
                    }
                ))
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jsonData = JsonConvert.SerializeObject(model);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var stopwatch = Stopwatch.StartNew();
                HttpResponseMessage response = await client.PostAsync(url, content);
                stopwatch.Stop();
                if (stopwatch.Elapsed.TotalSeconds > 2)
                {
                    AppendToFile($"{DateTime.Now.ToString()} - {model.ToString()} - {stopwatch.Elapsed.TotalSeconds} - Content: {jsonData}");
                }
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(data);
                    resultStatus = response.StatusCode == System.Net.HttpStatusCode.OK;
                    resultData = result;
                }
            }
            return resultStatus ? resultData : default(T);
        }
