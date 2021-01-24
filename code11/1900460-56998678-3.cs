    public class Links
    {
        public string next { get; set; }
        public string prev { get; set; }
        public string self { get; set; }
    }
    
    public class Links2
    {
        public string self { get; set; }
    }
    
    public class Kilometers
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }
    
    public class EstimatedDiameter
    {
        public Kilometers kilometers { get; set; }
    }
    
    public class AsteroidInfo
    {
        public Links2 links { get; set; }
        public string id { get; set; }
        public string neo_reference_id { get; set; }
        public string name { get; set; }
        public string nasa_jpl_url { get; set; }
        public double absolute_magnitude_h { get; set; }
        public EstimatedDiameter estimated_diameter { get; set; }
    }
    
    public class NearEarthObjects
    {
        //public Dictionary<string,AsteroidInfo[]> asteroid { get; set; }
        public Dictionary<DateTime,AsteroidInfo[]> asteroid { get; set; }
    }
    
    public class RootObject
    {
        public Links links { get; set; }
        public int element_count { get; set; }
        public NearEarthObjects near_earth_objects { get; set; }
    }
