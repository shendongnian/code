    internal class InternalExtendible
    {
        public string MyProperty { get; set; }
    }
    public sealed class ExternalSealedClass : InternalExtendible
    {
    }
