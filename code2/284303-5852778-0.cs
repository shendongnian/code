    public class CompositeObj
    {
        protected ObjectType1 obj1 { get; set; }
        protected ObjectType2 obj2 { get; set; }
    
        public CompositeObj(ObjectType1 obj1, ObjectType2 obj2)
        {
             this.obj1 = obj1;
             this.obj2 = obj2;
        }
    
        public string Property1 { get { return this.obj1.Property1; } }
        public string Property2 { get { return this.obj2.Property2; } }
        pulbic string Property3 { get { return this.obj1.Property1 + this.obj2.Property2; } }
    }
