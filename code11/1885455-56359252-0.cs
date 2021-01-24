    public class Parent
    {
        public int id { get; set; }
        public string name { get; set; }
        // every Parent has zero or more Children (one-to-many)
        public virtual ICollection<Child> Children { get; set; }
    }
    public class Child
    {
        public int id { get; set; }
        public string name { get; set; }
        // every Child is the child of exactly one Parent, using a foreign key
        public int ParentId {get; set;}
        public virtual Parent Parent {get; set;}
        // every Child has zero or more Child2 (one-to-many)
        public virtual ICollection<Child2> Children2 { get; set; }
    }
    public class Child2
    {
        public int id { get; set; }
        public string name { get; set; }
        // every Child2 belongs to exactly one Child, using foreign key
        public int ChildId {get; set;}
        public virtual Child Child {get; set;}
    }
