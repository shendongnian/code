     public class ClassA
    {
        public int ID { get; set; }
        public virtual ICollection<ClassB> ClassBs { get; set; }
        public bool ChangeMe { get; set; }
    }
    
    public class ClassB
    {
        public int ID { get; set; }
        public string test { get; set; }
        public bool bar { get; set; }
        public virtual ClassA ClassA { get; set; }
        public int ClassAID { get; set; }
    }
