    internal static class ProviderA
    {
       internal static void GetData(Action<string> callback)
        {
           callback?.Invoke(DataA.GetData());
        }
    }
    internal static class ProviderB
    {
       internal static void GetData(Action<string> callback)
        {
           callback?.Invoke(DataB.GetData());
        }
    }
    internal interface IProvider
    {
        internal void GetData(Action<string> callback);
    }
    internal sealed class ProviderAWrapper : IProvider
    {
        public void GetData(Action<string> callback)
        {
            ProviderA.GetData(callback);
        }
    }
    internal sealed class ProviderBWrapper : IProvider
    {
        public void GetData(Action<string> callback)
        {
            ProviderB.GetData(callback);
        }
    }
