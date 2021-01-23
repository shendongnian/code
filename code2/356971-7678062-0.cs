    public class District
    {
        public virtual ICollection<Installation> Installations { get; set; }
        [NotMapped]
        public int InstallationCount { get { return Installations.Count; } }
    }
