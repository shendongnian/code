    public static class ComponentMap
    {
        public static List<World> Worlds = new List<World>();
        public static List<Country> Countries = new List<Country>();
        public static List<Region> Regions = new List<Region>();
        public static List<City> Cities = new List<City>();
        public static List<Building> Buildings = new List<Building>();
        public static List<Effect> Effects = new List<Effect>();
    
        public static IDictionary<(ComponentType, int), object> Map = new Dictionary<(ComponentType, int), object>() {
            // etc
        };
    }
    
    private bool CheckExist()
    {
        ComponentType type = ComponentType.Country;
        ushort compId = 12;
    
        return ComponentMap.Map.ContainsKey((type, compId));
    }
