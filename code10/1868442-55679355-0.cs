    class MainGroup
    {
        public int Id {get; set;}
        ...
        // every MainGroup has zero or more SubGroups (one-to-many or many-to-many)
        public virtual ICollection<SubGroup> SubGroups {get; set;}
    }
    class SubGroup
    {
        public int Id {get; set;}
        ...
        // every SubGroup has zero or more Product(one-to-many or many-to-many)
        public virtual ICollection<Product> Products{get; set;}
        // alas I don't know the return relation
        // one-to-many: every SubGroup belongs to exactly one MainGroup using foreign key
        public int MainGroupId {get; set;}
        public virtual MainGroup MainGroup {get; set;}
        // or every SubGroup has zero or more MainGroups:
        public virtual ICollection<MainGroup> MainGroups {get; set;}
    }
