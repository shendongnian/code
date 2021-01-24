            private void Delete<T>(string uri, T value)
        {
            using (HttpClient _client = new HttpClient())
            {
                _client.BaseAddress = BaseAddress;
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string _url = string.Format("{0}/{1}", uri, value);
                var _response = _client.DeleteAsync(_url).Result;
            }
        }
