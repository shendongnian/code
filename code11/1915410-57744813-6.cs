    public class WebService {
        static Lazy<HttpClient> http = new Lazy<HttpClient>();
        public async Task<T> GetAsync<T>(string url) {        
            var json = await http.Value.GetStringAsync(url);
            return JsonConvert.DeserializeObject<T>(json);
        }
        public Task<StatsTeamsClass> GetTeams() {        
            var url = "https://statsapi.web.nhl.com/api/v1/teams?sportId=1";
            return GetAsync<StatsTeamsClass>(url);
        }
    }
