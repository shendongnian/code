    public class Foo : IFoo<int>
        {
            void IFoo<int>.Foo(int o)
            {
                throw new System.NotImplementedException();
            }
    
            void IFoo.Foo(object o)
            {
                throw new System.NotImplementedException();
            }
        }
