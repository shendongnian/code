    class Base
    {
        public virtual int A {get; set;}
        public int ShowA()
        {
            Console.WriteLine(A);
        }
    }
    
    class Derived : Base
    {
        public Derived()
        {
            A = 5;
        }
    
        [HideInInspector()]
        public override int A
        {
            get { return base.A;}
            set { base.A = value}
        }
    }
