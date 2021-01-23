    class Base
    {
        public int A {get; set;}
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
    
        [Browsable(false)]
        public new int A
        {
            get { return base.A;}
            set { base.A = value}
        }
    }
