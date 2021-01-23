    using System;
    
    class Foo
    {
        public string this[string text]
        {
            get { return text; }
        }
    
        public int this[int number]
        {
            get { return number; }
        }
    }
    
    class FooHolder
    {
        public Foo Foo { get; set; }
    }
    
    class Test
    {
        static void Main()
        {
            var holder = new FooHolder { Foo = new Foo() };
            
            int x = holder.Foo[10];
            string y = holder.Foo["hello"];
        }
    }
