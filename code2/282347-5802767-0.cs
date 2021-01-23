    public class Zone 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("NeighbourOf")]
        public virtual ICollection<Zone> NeighourTo { get; set; }
        [InverseProperty("NeighbourTo")]
        public virtual ICollection<Zone> NeighourOf { get; set; }
    }
