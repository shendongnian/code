                HttpClient myClient = new HttpClient();
                myClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var myToken = token;
                using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, "https://webchat.botframework.com/v3/conversations/ConversationID/activities"))
                {
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", myToken);
                    requestMessage.Content = new StringContent("{\"type\": \"message\", \"text\": \"I come from teams\", \"from\": {\"id\": \"bot@someID\", \"name\": \"teams\"}}", System.Text.Encoding.UTF8, "application/json");
                    var myResponse = await myClient.SendAsync(requestMessage);
                }
