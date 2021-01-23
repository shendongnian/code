    namespace IPersonExtensions
    {
        public static class IPersonExtensionClass
        {
            public static string Initial(this IPerson @this)
            {
                return @this.name.Substring(0, 1);
            }
        }
    }
