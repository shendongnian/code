    public class User : IdentityUser<int>
    {
        // member data here
        public Location Location { get; set; }
        [JsonIgnore]
        public Point LocationPoint { get; set; } // has lat/lng data points
    }
