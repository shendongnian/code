    public static class TypeExtensions
    {
        public static bool ImplementsInterface(this Type type, Type @interface)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }
            if (@interface == null)
            {
                throw new ArgumentNullException(nameof(@interface));
            }
            var interfaces = type.GetInterfaces();
            if (@interface.IsGenericTypeDefinition)
            {
                foreach (var item in interfaces)
                {
                    if (item.IsConstructedGenericType && item.GetGenericTypeDefinition() == @interface)
                    {
                        return true;
                    }
                }
            }
            else
            {
                foreach (var item in interfaces)
                {
                    if (item == @interface)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
