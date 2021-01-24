    public class Vals{
       
        private IHttpClientFactory httpClientFactory;
       
        public Vals(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory
        }
        private async Task<Movie> GetMovies()
        {
            // Get an instance of HttpClient from the factpry that we registered
            // in Startup.cs
            var client = httpClientFactory.CreateClient("API Client");
            // Call the API & wait for response. 
            // If the API call fails, call it again according to the re-try policy
            // specified in Startup.cs
            var result = await client.GetAsync("/api.themoviedb.org/3/discover/movie?api_key=6&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1");
            if (result.IsSuccessStatusCode)
            {
                // Read all of the response and deserialise it into an instace of
                // Movie class
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Movie>(content);
            }
            return null;
        }
    }
   
