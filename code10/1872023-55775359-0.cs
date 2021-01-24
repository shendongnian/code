    public class Child
    {
        public int ChildID { get; set; }
        public string ChildName { get; set; }
        // EF will make FK by convention
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int? FavoriteOfParentId { get; set; }
        public Parent FavoriteOfParent { get; set; }
    }
    public class Parent
    {
        public int ParentId { get; set; }
        public string ParentName { get; set; }
        public int FavoriteChildId {get;set;}           
        [InverseProperty("FavoriteOfParent")]
        public Child FavoriteChild {get;set;}            
        
        [InverseProperty("Parent")]
        public ICollection<Child> Children { get; set; }
    }
