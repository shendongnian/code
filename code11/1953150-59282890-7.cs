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
                
                if (result.StatusCode == HttpStatusCode.OK)
                {
                    // do something
                }
                // to read the content as string
                var stringResult = await result.Content.ReadAsStringAsync();
                // to deserialize the content as some entity
                var someEntity = await result.Content.ReadAsAsync<MyCustomObject>();
            }
