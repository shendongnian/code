    public class VenueLogic {
        static HttpClient client = new HttpClient();
        
        public async static Task<List<Venue>> getVenues(double latitude, double longitude) {
            var url = VenueRoot.GenerateUrl(latitude, longitude);
            var response = await client.GetAsync(url);
            var jsonContent = await response.Content.ReadAsStringAsync();
            var venueRoot = JsonConvert.DeserializeObject<VenueRoot>(jsonContent);
            List<Venue> vanues = venueRoot.response.venues as List<Venue>;
            return vanues;
        }
    }
