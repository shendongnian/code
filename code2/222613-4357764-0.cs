    class Derived : Base
    {
        public override void Foo()
        {
            Console.WriteLine("Derived");
        }
    
        public void BaseFoo()
        {
            base.Foo();
        }
    }
