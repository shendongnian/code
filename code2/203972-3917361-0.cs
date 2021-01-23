    interface ISignatur<T>
    {
        Type Type { get; }
    }
    interface IAccess<T>
    {
        ISignatur<T> Signature { get; }
        T Value { get; set; }
    }
    class Signatur : ISignatur<bool>
    {
        public Type Type
        {
            get { return typeof(bool); }
        }
    }
    class ServiceGate
    {
        public IAccess<T> Get<T>(ISignatur<T> sig)
        {
            throw new NotImplementedException();
        }
    }
    static class Test
    {
        static void Main()
        {
            ServiceGate service = new ServiceGate();
            var access = service.Get(new Signatur());
        }
    }
