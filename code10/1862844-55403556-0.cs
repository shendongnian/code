        static async Task Main()
        {
            var bingKey = "**********************";
            var request = new GeocodeRequest()
            {
                Query = "Via Ravenna 10, Milano",
                IncludeIso2 = true,
                IncludeNeighborhood = true,
                MaxResults = 25,
                BingMapsKey = bingKey
            };
            //Process the request by using the ServiceManager.
            var response = await request.Execute();
            if (response != null &&
                response.ResourceSets != null &&
                response.ResourceSets.Length > 0 &&
                response.ResourceSets[0].Resources != null &&
                response.ResourceSets[0].Resources.Length > 0)
            {
                var result = response.ResourceSets[0].Resources[0] as Location;
                var coords = result.Point.Coordinates;
                if (coords != null && coords.Length == 2)
                {
                    var lat = coords[0];
                    var lng = coords[1];
                    Console.WriteLine($"Geocode Results - Lat: {lat} / Long: {lng}");
                }
            }
        }
