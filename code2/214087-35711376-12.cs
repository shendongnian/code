    public interface ITokenResolver
    {
        MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments);
        Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments);
        FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments);
        MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments);
        byte[] ResolveSignature(int metadataToken);
        string ResolveString(int metadataToken);
    }
    
