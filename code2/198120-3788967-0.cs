    using MiscUtil.Reflection;
    
    class A
    {
        public int Foo { get; set; }
    }
    
    class B
    {
        public int Foo { get; set; }
    }
    
    class Program
    {
        static void Main()
        {
            A a = new A();
            a.Foo = 17;
            B b = PropertyCopy<B>.CopyFrom(a);
    
            bool success = b.Foo == 17; // success is true;
        }
    }
