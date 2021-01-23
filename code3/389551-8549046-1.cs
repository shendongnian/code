    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple=false)]
    public class NetworkMessageAttribute : Attribute
    {
        public byte MessageID { get; set }
    }
