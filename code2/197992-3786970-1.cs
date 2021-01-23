    public class Coordinate
    {
        public double Longitude { get; set; }
    
        public double Latitude { get; set; }
    }
    
    ...
    
    JavaScriptSerializer jSerialize = new JavaScriptSerializer();
    var coordinate = jSerialize.Deserialize<Coordinate>(configuration);
