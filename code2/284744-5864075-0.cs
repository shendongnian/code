    public class Location
    {
        public bool IsExpanded { get; set; }
        public string Name { get; set; }
        public List<Location> Locations { get; set; }
    }
    
    public class ViewModel
    {
        public List<Location> RootLocations { get; set; }
    }
