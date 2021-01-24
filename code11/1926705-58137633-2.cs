    public static class ApiHelper
    {
        public static int PoolSize { get => apiClientPool.Size; }
        private static ArrayPool<HttpClient> apiClientPool = new ArrayPool<HttpClient>(() => {
            var apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Add("ContentType", "application/json");
            return apiClient;
        });
        public static Task Use(string apiToken, Func<HttpClient, Task> action)
        {
            return apiClientPool.Use(client => {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);
                return action(client);
            });
        }
    }
