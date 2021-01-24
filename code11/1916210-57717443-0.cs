    private double GetSqrDistanceBetweenPoints(GeoCoordinate point1, GeoCoordinate point2)
    {
        return Math.Pow(Convert.ToDouble(point1.Latitude) - point2.Latitude, 2) +
               Math.Pow(Convert.ToDouble(point1.Longitude) - point2.Longitude, 2);
    }
    private List<GeoCoordinate> Test(List<GeoCoordinate> zipCodeList, GeoCoordinate searchedItem)
    {
        var zipMatches = zipCodeList
            .ToLookup(x => GetSqrDistanceBetweenPoints(x, searchedItem))
            .OrderBy(x => x.Key)
            .FirstOrDefault()?
            .ToList();
        return zipMatches;
    }
