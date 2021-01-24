    public static class ApiHelper
    {
        public static HttpClient Create(string token) { 
            var apiClient = new HttpClient();
            apiClient.DefaultRequestHeaders.Add("ContentType", "application/json");
            apiClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            return apiClient;
        }
    }
