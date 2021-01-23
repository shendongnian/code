    [StructLayout(LayoutKind.Explicit)]
    [CLSCompliant(false)]
    public struct NumberStackEntry
    {
        /// <summary>Type of entry</summary>
        [FieldOffset(0)]
        public EntryTypes entryType;
        /// <summary>Value if double</summary>
        [FieldOffset(4)]
        public double dval;
        /// <summary>Value if ulong</summary>
        [FieldOffset(4)]
        public ulong uval;
        /// <summary>Value if long</summary>
        [FieldOffset(4)]
        public long lval;
        /// <summary>Value if integer</summary>
        [FieldOffset(4)]
        public int ival;
    }
        
