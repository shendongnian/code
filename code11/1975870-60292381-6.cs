    MapLocationFinderResult result =
              await MapLocationFinder.FindLocationsAsync(
                               BuildingNumber  + ", " + PostCode, null);
    if (result.Status == MapLocationFinderStatus.Success)
    {
        var temp = "result = (" +
           result.Locations[0].Point.Position.Latitude.ToString() + "," +
        result.Locations[0].Point.Position.Longitude.ToString() + result.Locations[0].DisplayName + result.Locations[0].Address.Street + ")";
    
        BasicGeoposition location = new BasicGeoposition();
        location.Latitude = result.Locations[0].Point.Position.Latitude;
        location.Longitude = result.Locations[0].Point.Position.Longitude;
        Geopoint pointToReverseGeocode = new Geopoint(location);
    
        // Reverse geocode the specified geographic location.
        MapLocationFinderResult MyResult =
              await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);
    
        // If the query returns results, display the name of the town
        // contained in the address of the first result.
        if (result.Status == MapLocationFinderStatus.Success)
        {
            var text = "Street = " +
                  MyResult.Locations[0].Address.Street;
        }
    }
