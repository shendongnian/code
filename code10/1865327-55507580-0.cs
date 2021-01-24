        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://localhost");
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, "users");
                httpRequest.Content = new StringContent("{name:'admin'}");
                var httpResponse = await httpClient.SendAsync(httpRequest);
                //process http response
            }
        }
