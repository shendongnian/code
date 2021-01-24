    public class Location {
        public Location(double lat, double lon) {
            Latitude = lat;
            Longitude = lon;
        }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }    
    }
    public class PostcodeService {
        private static Lazy<HttpClient> client;
        static PostcodeService() {
            client = new Lazy<HttpClient>(() => {
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://api.postcodes.io/postcodes/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                return httpClient;
            });
        }
        
        public async Task<Location> GetLongLatAsync(string postcode) {}
            var response = await client.Value.GetAsync(postcode);
            if(response.IsSuccessStatusCode) {
                //cast result into model and then set long/lat properties which can then be used in the UI
                var rootObject = await response.Content.ReadAsAsync<RootObject>();
                var Longitude = Double.Parse(rootObject.result.longitude.ToString());
                var Latitude =  Double.Parse(rootObject.result.latitude.ToString());
                var result = new Location(Latitude, Longitude);
                return result;
            }
            return null;
        }
    }
    
