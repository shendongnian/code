    interface IFooBar
    {
        void Foo();
        void Bar();
    }
    
    class FooBar : IFooBar
    {
        void IFooBar.Foo()
        {
        }
    
        void IFooBar.Bar()
        {
            ((IFooBar)this).Foo();
        }
    }
