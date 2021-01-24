            // To creat HttpClient
            var client = new HttpClient();
            // Accesstoken
            var accessToken = "my token";
            // URL
            var url = "https://api.line.me/v2/bot/message/broadcast";
            // Post
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            // Request Header
            request.Headers.Add("Authorization", "Bearer " + accessToken);
            // To create messages
            var message1 = new Message("text", "Hello World1");
            var message2 = new Message("text", "Hello World2");
            var root = new RootObject();
            root.addMessage(message1);
            root.addMessage(message2);
            // To serialize
            var json = JsonConvert.SerializeObject(root);
            request.Content = new StringContent(
                json.ToString(),
                Encoding.UTF8,
                "application/json"
            );
            await client.SendAsync(request);
