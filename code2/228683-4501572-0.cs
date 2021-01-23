    public interface IBar
    {
        void Bar();
    }
    
    public interface IFoo:IBar
    {
        void Foo();
        new void Bar();
    }
    public class Class1 : IFoo
    {
        void Bar()
        {
        }
        #region IFoo Members
        void IFoo.Foo()
        {
            //...
        }
        void IFoo.Bar()
        {
            //...
        }
        #endregion
        #region IBar Members
        void IBar.Bar()
        {
            //...
        }
        #endregion
    }
