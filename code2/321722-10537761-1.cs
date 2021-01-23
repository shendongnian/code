        static void Main(string[] args)
        {
            string address = "http://api.worldbank.org/countries?format=json";
            Task t = LoadJsonAsync(address);
            // do other work while loading
            t.Wait();
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }
        private async static Task<HttpResponseMessage> LoadJsonAsync(string address)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(address);
            // Check that response was successful or throw exception
            response.EnsureSuccessStatusCode();
            // Read response asynchronously as JsonValue and write out top facts for each country
            JsonArray readTask = await response.Content.ReadAsAsync<JsonArray>();
            Console.WriteLine("First 50 countries listed by The World Bank...");
            foreach (var country in readTask[1])
            {
                Console.WriteLine("   {0}, Capital: {1}",
                    country.Value["name"],
                    country.Value["capitalCity"]);
            }
            return response;
        }
