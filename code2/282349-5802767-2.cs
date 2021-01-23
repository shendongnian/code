    public class Zone 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("NeighbourOf")]
        public virtual ICollection<Zone> NeighbourTo { get; set; }
        [InverseProperty("NeighbourTo")]
        public virtual ICollection<Zone> NeighbourOf { get; set; }
    }
