    [Serializable, 
    DebuggerDisplay("ThreadSafetyMode={Mode}, IsValueCreated={IsValueCreated}, IsValueFaulted={IsValueFaulted}, Value={ValueForDebugDisplay}"), 
    DebuggerTypeProxy(typeof(System_LazyDebugView<>)), ComVisible(false), HostProtection(SecurityAction.LinkDemand, Synchronization=true, ExternalThreading=true)]
    public class Lazy<T>
    {
    ...
    }
