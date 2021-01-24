    public class SyncLog
    {
        public string[] sl_Struct { get; set; }
        public int sl_StructLength => sl_Struct?.Length ?? 0;
    }
    ...
    PropertyGroupDescription group = new PropertyGroupDescription("sl_StructLength ");
