    internal class WebApiClient  : IDisposable
      {
        private bool _isDispose;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!_isDispose)
            {
                if (disposing)
                {
                }
            }
            _isDispose = true;
        }
		private void SetHeaderParameters(WebClient client)
        {
            client.Headers.Clear();
            client.Headers.Add("Content-Type", "application/json");
            client.Encoding = Encoding.UTF8;
        }
		public async Task<T> PostJsonWithModelAsync<T>(string address, string data,)
        {
            using (var client = new WebClient())
            {
                SetHeaderParameters(client);
                string result = await client.UploadStringTaskAsync(address, data); //  method:
        //The HTTP method used to send the file to the resource. If null, the default is  POST 
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
