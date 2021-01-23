        private void HttpSendProgress(object sender, HttpProgressEventArgs e)
        {
            HttpRequestMessage request = sender as HttpRequestMessage;
            Console.WriteLine(e.BytesTransferred);
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            ProgressMessageHandler progress = new ProgressMessageHandler();
            progress.HttpSendProgress += new EventHandler<HttpProgressEventArgs>(HttpSendProgress);
            HttpRequestMessage message = new HttpRequestMessage();
            StreamContent streamContent = new StreamContent(new FileStream("e:\\somefile.zip", FileMode.Open));
            message.Method = HttpMethod.Put;
            message.Content = streamContent;
            message.RequestUri = new Uri("{Here your link}");
           
            var client = HttpClientFactory.Create(progress);
            client.SendAsync(message).ContinueWith(task =>
            {
                if (task.Result.IsSuccessStatusCode)
                { 
                    
                }
            });
        }
