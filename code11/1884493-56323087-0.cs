    [Serializable]
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
    
