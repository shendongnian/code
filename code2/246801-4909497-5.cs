    class Place: IEquatable<Place>
    {
        public int longitude { get; set; }
        public int latitude { get; set; }
        public string title { get; set; }
    
        public Place (int long, int lat, string ttl)
        {
            // initialization here
        }
    
        public bool Equals(Place other)
        {
            return (this.longitude == other.longitude) && (this.latitude == other.latitude);
        }
    }
    
    ...
    HashSet<Place> Places = new HashSet<Place>();
    
    foreach (var item in eventsList)
    {
        var place = new Place(item.Title, item.Longitude, item.Latitude);
        while (!Places.Add(place))
        {
            // Adjust place.Latitude
        }
    }
    // Finally, convert it to a list.
    List<Place> Placelist = Places.ToList();
