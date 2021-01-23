    public class Container
    {
        public string Name { get; set; }
        public int Volume { get; set; }
    
        public int MaskedVolume {
            get {
                return (Name.Contains ("SPECIAL", StringComparison.OrdinalIgnoreCase))
                    ? -1
                    : Volume;
            }
        }
    }
