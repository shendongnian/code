    public List<Region> regions = new List<Region>();
    
    public class Region
    {
        public int x_size;
        public int y_size;
    
        public enum terrain
        {
            desert,
            lowlands,
            crater,
            city
        };
    
        public terrain ground;
    }
    
    private void NewRegion()
    {
        Region thisRegion = new Region();
        thisRegion.x_size = Random.Range(25, 50);
        thisRegion.y_size = Random.Range(25, 50);
        thisRegion.ground = Region.terrain.desert;
        regions.Add(thisRegion);
    }
