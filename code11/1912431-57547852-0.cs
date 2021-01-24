    public class GetResults {
        
        public static async Task<List<Result>> GetDataAsync(string url) {
            var client = new RestClient();
            var request = new RestRequest(url, Method.GET);
            request.AddHeader("User-Agent", "Nothing");
            IRestResponse<List<Result>> results = await client.ExecuteTaskAsync<List<Result>>(request);
            return results.Data;
        }
    }
