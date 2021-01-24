    //Entities
    
    public class Parent
    {
        public int ParentId { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        // ...
        public virtual ICollection<Child> Children { get; set; } = new List<Child>();
    }
    
    public class Child
    {
        public int ChildId { get; set; }
        // ...
        public virtual Parent Parent { get; set; }
        public virtual ChildType ChildType { get; set; }
        public virtual Status Status { get; set; }
    }
    
    public class ChildType
    {
        public int ChildTypeId { get; set; }
        // ...
    }
    
    public class Status
    {
        public int StatusId { get; set; }
        // ...
    }
