    public class Base : IInterface
    {
        virtual void IInterface.Method()
        {
           throw new NotImplementedException();
        }
    }
