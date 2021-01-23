    namespace ConsoleApplication1
    {
        class A
        {
            public virtual void Speak()
            {
                Hello();
            }
            virtual protected void Hello()
            {
                Console.WriteLine("Hello from A");
            }
        }
    
        class B : A
        {
            public override void Speak()
            {
                base.Hello(); //Hello from A
                this.Hello(); //Hello from B
            }
            
            override protected void Hello()
            {
                Console.WriteLine("Hello from B");
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
              
                B b = new B();
                b.Speak();
            }
        }
    }
