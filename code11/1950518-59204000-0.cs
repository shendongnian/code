        var request = new DistanceMatrixRequest()
        {
            BingMapsKey = bingApiKey,
            Origins = new List<SimpleWaypoint>
            {
                new SimpleWaypoint(new Coordinate(vehiclePosition.Latitude, vehiclePosition.Longitude))
            },
            Destinations = destinationWaypoints,
            TravelMode = TravelModeType.Driving,
            VehicleSpec = new VehicleSpec
            {
                VehicleLength = 16.5,
                VehicleWeight = 20000
            }
        };
        var response = request.Execute().Result; // Or await request.Execute()
