    public interface IMyService
    {
        //.... service-specific methods you'll be using
    }
    public interface IStubLoader
    {
        Object CreateInstanceFromAndUnwrap(byte[] assemblyBytes, string typeName);
    }
