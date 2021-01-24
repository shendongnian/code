     static async Task PostRequestAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:6740");
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("", "login")
                });
                var result = await client.PostAsync("/api/Membership/exists", content);
                string resultContent = await result.Content.ReadAsStringAsync();
                Console.WriteLine(resultContent);
            }
        }
