    public class PlaceConversion
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
    }
    public class Place
    {
        public Place(string placeID, PlaceConversion placeDetails)
        {
            this.PlaceID = Convert.ToInt32(placeID);
            this.Latitude = placeDetails.Latitude;
            this.Longitude = placeDetails.Longitude;
            this.Name = placeDetails.Name;
        }
        public int PlaceID { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Name { get; set; }
    }
