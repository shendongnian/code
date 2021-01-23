    public void ValidateUri(String uri)
        {
            if (!Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute)) return;
            request = WebRequest.Create(uri);
            request.BeginGetResponse(new AsyncCallback(ValidateUriCallback), null);
        }
        private WebRequest request;
        private void ValidateUriCallback(IAsyncResult result)
        {
            try
            {
                WebResponse httpResponse = (WebResponse)request.EndGetResponse(result);
                // Create the client here
                ServiceClient client = new MyServiceClient(myBinding, myEndpointAddress);
            client.RegisterUserCompleted += new EventHandler<RegisterUserCompletedEventArgs>(client_RegisterUserCompleted);
            client.RegisterUserAsync();
        
            }
            catch (WebException ex)
            {
                var response = ex.Response as System.Net.HttpWebResponse;
        if (response!=null 
            && response.StatusCode == HttpStatusCode.NotFound)
        {
            Dispatcher.BeginInvoke(delegate()
                    {
                        MessageBox.Show("The web service address is not valid", "Sorry", MessageBoxButton.OK);
                     });
        }
            }
