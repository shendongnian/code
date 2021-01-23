    public class GuidModel
    {
        [Required]
        public Guid? Guid { get; set; }
        public IEnumerable<Guid> Guids { get; set; }
    }
