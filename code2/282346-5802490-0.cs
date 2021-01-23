    public class Zone {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Zone> Neighours { get; set; }
    }
