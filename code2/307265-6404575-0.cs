    interface IDoNotOwnWrapper
    {
        event EventHandler<SomeEventArgs> SomeEvent;
    }
    class DoNotOwnWrapper : IDoNotOwnWrapper
    {
        DoNotOwn _internal;
        public DoNotOwnWrapper()
        {
             _internal = new DoNotOwn();
             _internal.SomeEvent += SomeEvent;
        } 
        event EventHandler<SomeEventArgs> SomeEvent;
    }
