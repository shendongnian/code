    class Product
    {
        public int Id {get; set;}
        public bool? IsActive {get; set;} // might be a non-nullable property
        ...
        // alas I don't know the return relation
        // one-to-many: every Productbelongs to exactly one SubGroup using foreign key
        public int SubGroupId {get; set;}
        public virtual SubGroup SubGroup {get; set;}
        // or every Product has zero or more SubGroups:
        public virtual ICollection<SubGroup> SubGroups {get; set;}
    }
