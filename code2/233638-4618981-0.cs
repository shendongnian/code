    public static bool ImplementsOpenInterface(Type type, Type openInterfaceType) {
        Contract.Requires(type != null);
        Contract.Requires(openInterfaceType != null);
        Contract.Requires(openInterfaceType.IsGenericTypeDefinition);
        Type[] interfaces = type.GetInterfaces();
        if (interfaces == null) {
            return false;
        }
        return interfaces
            .Where(x => x.IsGenericType)
            .Select(x => x.GetGenericTypeDefinition())
            .Any(x => x == openInterfaceType);
    }
