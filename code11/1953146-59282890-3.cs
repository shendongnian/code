            var list = new List<Task<HttpResponseMessage>>();
            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("some uri"),
                Headers = {
                    // headers
                }
            };
            for (int i = 0; i < 10; i++)
            {
                list.Add(client.SendAsync(httpRequestMessage));
            }
            await Task.WhenAll(list);
            foreach (var task in list)
            {
                var result = await task;
            }
