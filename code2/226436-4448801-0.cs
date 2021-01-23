    class Base
        {
            public virtual void SayHello()
            {
                Console.WriteLine("Hello from base");
            }
        }
    
        class Derived : Base
        {
            public override void SayHello()
            {
                Console.WriteLine("Hello from derived");
            }
        }
