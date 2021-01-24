    [Guid("65019f75-8da2-497c-b32c-dfa34e48ede6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDerived : IBase
    {
        // IBase methods
        new int Blabla();
        
        // IDerived methods
        ...
    }
