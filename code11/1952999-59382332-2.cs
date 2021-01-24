    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromRawBodyAttribute : Attribute, IBindingSourceMetadata
    {
        public BindingSource BindingSource => CustomBindingSources.RawBody;
    }
