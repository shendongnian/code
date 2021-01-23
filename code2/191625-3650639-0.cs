    namespace SampleApp
    {    
        interface IFoo
        {
            void M();
        }
    
        class Foo : IFoo
        {
            void IFoo.M()
            {
                Console.WriteLine("M");
            }
        }
    }
