    public class Child
    {
        public int Id { get; set; }
        // add these navigation properties to access the Parent
        public int ParentId {get; set; }
        public Parent Parent {get; set; }
    }
