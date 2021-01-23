    public class Container
    {
        public string Name { get; set; }
        public int Volume { get; set; }
    
        public int MaskedVolume {
            get {
                return (Name.IndexOf ("SPECIAL", StringComparison.OrdinalIgnoreCase) >= 0)
                    ? Volume
                    : -1;
            }
        }
    }
