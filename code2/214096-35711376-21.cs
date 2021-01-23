    public sealed class ModuleTokenResolver : ITokenResolver
    {
        private readonly Module module;
        public ModuleTokenResolver(Module module)
        {
            this.module = module;
        }
        public MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments) =>
            module.ResolveMember(metadataToken, genericTypeArguments, genericMethodArguments);
        public Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments) =>
            module.ResolveType(metadataToken, genericTypeArguments, genericMethodArguments);
        public FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments) =>
            module.ResolveField(metadataToken, genericTypeArguments, genericMethodArguments);
        public MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments) =>
            module.ResolveMethod(metadataToken, genericTypeArguments, genericMethodArguments);
        public byte[] ResolveSignature(int metadataToken) =>
            module.ResolveSignature(metadataToken);
        public string ResolveString(int metadataToken) =>
            module.ResolveString(metadataToken);
    }
    
