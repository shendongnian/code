    public static class Extensions
    {
        public static bool IsImplementationOf(this System.Type objectType, System.Type interfaceType)
        {
            return (objectType.GetInterface(interfaceType.FullName) != null);
        }
    }
