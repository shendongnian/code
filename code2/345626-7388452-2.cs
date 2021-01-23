    [AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = true)]
    public sealed class DtoProviderAttribute : Attribute
    {
        public Type ProvidedType { get; private set; }
        public Type ProviderType { get; private set; }
        public DtoProviderAttribute(Type providedType, Type providerType)
        {
            ProvidedType = providedType;
            ProviderType = providerType;
        }
    }
