    using System;
    using Rhino.Mocks;
    
    public abstract class Abstract
    {
        public virtual int Foo()
        {
            return Bar() * 2;
        }
        
        public abstract int Bar();        
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            MockRepository repository = new MockRepository();
            Abstract mock = repository.PartialMock<Abstract>();
            
            using (repository.Record())
            {
                Expect.Call(mock.Bar()).Return(5);
            }
            
            Console.WriteLine(mock.Foo()); // Prints 10
        }
    }
