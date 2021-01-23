    [AttributeUsage(AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : System.ComponentModel.DisplayNameAttribute
    {
        public EnumDisplayNameAttribute(string data) : base(data) { }
    }
    public enum Resolution_ : byte
    {
        DCIF,
        CIF,
        QCIF,
        [EnumDisplayName("4CIF")]
        CIF4,
        [EnumDisplayName("2CIF")]
        CIF2
    }
