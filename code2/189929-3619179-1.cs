    #if NUNIT
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class HostTypeAttribute : Attribute
    {
        public HostTypeAttribute(string dummy) { }
    }
    #else
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class MoledAttribute : Attribute
    {
        public MoledAttribute() { }
    }
    #endif
