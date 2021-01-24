    public class Owner : EntityBase<Guid>
    {
        public string Name { get; set; }
    
        [NotMapped]
        public ICollection<Cow> CowOwners { get; set; } // CowOwners instead of Cows ?
            = new List<Cow>();
    
        public virtual List<OwnerCow> OwnerCow { get; set; } // OwnerCow instead  of CowOwners ?
        public Cow Cow { get; set; }
    }
