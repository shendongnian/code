      public async Task CallAPIAsync(List<string> objFileNameList)
        {
            var Info = new APIModel
            {
                filePaths = objFileNameList,
                bucketAsDir = "false"
            };
            string request = JsonConvert.SerializeObject(Info);
            using (var client = new HttpClient())
            {
                client.Timeout = Timeout.InfiniteTimeSpan;
                var stringContent = new StringContent(request, UnicodeEncoding.UTF8, "application/json");
                client.BaseAddress = new Uri("eg.api.stackflow.com/post");
                var response = await client.PostAsync("post", stringContent);
                var message = response.Content.ReadAsStringAsync().Result;
            }
        }
