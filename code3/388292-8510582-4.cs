    public abstract class MyBaseClass
    {
        public string Name { get; set; }
        public string Signature { get; set; }
        public int Checksum { get; set; }
    
        public void CreateChecksum() // Your helper method
        {
            Checksum = Name.GetHashCode() ^ Signature.GetHashCode();
        }
    }
