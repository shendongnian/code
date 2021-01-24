    public abstract class TypedClass
    {
        public string type { get; set; }
    }
    public class Envelope : TypedClass
    {
        public List<Feature> features { get; set; }
        public GeoJSONObject ToGeoJSON()
        {
            return new GeoJSONObject()
            {
                type = type,
                features = new List<GeoJSONFeature>(features.Select(x => x.ToGeoJSONFeature()))
            };
        }
    }
    public class Feature
    {
        [JsonProperty("Name ")]
        public string Name { get; set; }
        public string Status { get; set; }
        public string imageUrl { get; set; }
        public float lat { get; set; }
        public float Lon { get; set; }
        public GeoJSONFeature ToGeoJSONFeature()
        {
            return new GeoJSONFeature()
            {
                type = "Feature",
                properties = this,
                geometry = new Geometry()
                {
                    type = "Point",
                    coordinates = new List<double>() { -67.215500, 34.310100 }
                }
            };
        }
    }
    public class GeoJSONObject : TypedClass
    {
        public List<GeoJSONFeature> features { get; set; }
    }
    public class GeoJSONFeature : TypedClass
    {
        public Feature properties { get; set; }
        public Geometry geometry { get; set; }
    }
    public class Geometry : TypedClass
    {
        public List<double> coordinates { get; set; }
    }
