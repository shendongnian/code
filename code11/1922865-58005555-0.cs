    public class Owner : EntityBase<Guid>
    {
        public string Name { get; set; }   
 
        public virtual List<OwnerCow> OwnerCows { get; set; }
    }
    public class Cow : EntityBase<Guid>
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public ICollection<Entities.Weight> Weights { get; set; } = new List<Weight>();
        public ICollection<Vaccination> Vaccinations { get; set; }= new List<Vaccination>();
        public List<OwnerCow> OwnerCows { get; set; }
    }
    public class OwnerCow
    {
        [Key]
        public Guid OwnerCowId { get; set; }
        public Cow Cow { get; set; }
        public Guid CowId { get; set; }
        public Owner Owner { get; set; }
        public Guid OwnerId { get; set; }
    }
