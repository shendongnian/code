    #if NETFX_CORE // Workaround for .Net for Windows Store not having Type.GetProperty method
        public static class GetPropertyHelper
        {
            public static PropertyInfo GetProperty(this Type type, string propertyName)
            {
                return type.GetTypeInfo().GetDeclaredProperty(propertyName);
            }
        }
    #endif
