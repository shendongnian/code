        List<WebsiteGeoLocation> geoList = null;
        internal List<WebsiteGeoLocation> FindGeo(string searchText, int maxResults)
        {
            // get geolocations from the cache
            var result = from l in HttpRuntime.Cache["WebsiteGeoLocations"] as FeederService.GeoLocationCollection
                         where l.GeoDisplay.Contains(searchText)
                         orderby l.GeoDisplay
                         select l;
            geoList = new List<WebsiteGeoLocation>();
            foreach (FeederService.GeoLocation location in result)
            {
                geoList.Add(new WebsiteGeoLocation
                {
                    GeoID = location.GeoID,
                    GeoDisplay = location.GeoDisplay,
                    GeoCity = location.GeoCity,
                    GeoState = location.GeoState,
                    WebsiteID = location.WebsiteID,
                    WorldCitiesID = location.WorldCitiesID
                });
            }
            return geoList.Take(maxResults).ToList();
        }
