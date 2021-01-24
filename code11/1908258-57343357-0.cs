    // WeatherService.cs
    using System.Threading.Tasks;
    using System.Net.Http; //<-- THIS WAS MISSING
    namespace MyBlazorApp.Shared {
        public interface IWeatherService {
            Task<Weather> Get(decimal latitude, decimal longitude);
        }
    
        public class WeatherService : IWeatherService {
            private HttpClient httpClient;
            public WeatherService(HttpClient httpClient) {
                this.httpClient = httpClient;
            }
    
            public async Task<Weather> Get(decimal latitude, decimal longitude) {
                // Do stuff
            }
    
        }
    }
