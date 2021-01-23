    [AttributeUsage(AttributeTargets.Class, true, false)]
    public class NetworkMessageAttribute : Attribute
    {
        public byte MessageID { get; set }
    }
