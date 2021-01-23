        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            var request = WebRequest.Create("http://www.microsoft.com");
            var asyncResult = request.BeginGetResponse(
                ar =>
                {
                    using (var response = request.EndGetResponse(ar))
                    using (var responseStream = response.GetResponseStream())
                    using (var reader = new StreamReader(responseStream))
                    {
                        string content = reader.ReadToEnd();
                    }
                }, null);
        }
