    #if !NETCOREAPP3_0
    namespace System.Reflection
    {
        public interface ICustomTypeProvider
        {
            Type GetCustomType ();
        }
    }
    #endif
