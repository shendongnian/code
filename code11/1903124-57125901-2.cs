        public class ApiResult<T>
      {
        public IEnumerable<T> List { get; set; }
        public T Object { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string Url { get; set; }
        public static ApiResult<T> Post(string uri, string url, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMilliseconds(1800000);
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
                }
                HttpResponseMessage response = client.PostAsync(url, null).Result;
                return Result(response);
            }
        }
        public static ApiResult<T> Get(string uri, string url, string token = null)
        {
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromMilliseconds(1800000);
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", token);
                }
                HttpResponseMessage response = client.GetAsync(url).Result;
                return Result(response);
            }
        }
        private static ApiResult<T> Result(HttpResponseMessage response)
        {
            ApiResult<T> result = response.Content.ReadAsAsync<ApiResult<T>>().Result;
            if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
            {
                result.StatusCode = response.StatusCode;
            }
            if (response.IsSuccessStatusCode)
            {
                result.Success = true;
            }
            return result;
        }
    }
