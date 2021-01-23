    #if NUNIT
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class HostType: Attribute
    {
        public HostType(string dummy) { }
    }
    #else
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class Moled: Attribute
    {
        public Moled() { }
    }
    #endif
