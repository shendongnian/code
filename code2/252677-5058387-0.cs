    class CentroidReader
    {
        public static Centroid ReadControid(Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Response));
            Response response = serializer.ReadObject(stream) as Response;
            return response.Place.Centroid;
        }
    }
    [DataContract]
    class Response
    {
        [DataMember(Name = "place")]
        public Place Place { get; set; }
    }
    [DataContract]
    class Place
    {
        [DataMember(Name = "centroid")]
        public Centroid Centroid { get; set; }
    }
    [DataContract]
    class Centroid
    {
        [DataMember(Name = "latitude")]
        public double? Latitude { get; set; }
        [DataMember(Name = "longitude")]
        public double? Longitude { get; set; }
    }
