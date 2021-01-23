    public static class B
    {
        public static readonly V _0000 = 0x0;
        public static readonly V _0001 = 0x1;
        public static readonly V _0010 = 0x2;
        public static readonly V _0011 = 0x3;
        public static readonly V _0100 = 0x4;
        public static readonly V _0101 = 0x5;
        public static readonly V _0110 = 0x6;
        public static readonly V _0111 = 0x7;
        public static readonly V _1000 = 0x8;
        public static readonly V _1001 = 0x9;
        public static readonly V _1010 = 0xA;
        public static readonly V _1011 = 0xB;
        public static readonly V _1100 = 0xC;
        public static readonly V _1101 = 0xD;
        public static readonly V _1110 = 0xE;
        public static readonly V _1111 = 0xF;
        public struct V
        {
            ulong Value;
            public V(ulong value)
            {
                this.Value = value;
            }
            private V Shift(ulong value)
            {
                return new V((this.Value << 4) + value);
            }
            public V _0000 { get { return this.Shift(0x0); } }
            public V _0001 { get { return this.Shift(0x1); } }
            public V _0010 { get { return this.Shift(0x2); } }
            public V _0011 { get { return this.Shift(0x3); } }
            public V _0100 { get { return this.Shift(0x4); } }
            public V _0101 { get { return this.Shift(0x5); } }
            public V _0110 { get { return this.Shift(0x6); } }
            public V _0111 { get { return this.Shift(0x7); } }
            public V _1000 { get { return this.Shift(0x8); } }
            public V _1001 { get { return this.Shift(0x9); } }
            public V _1010 { get { return this.Shift(0xA); } }
            public V _1011 { get { return this.Shift(0xB); } }
            public V _1100 { get { return this.Shift(0xC); } }
            public V _1101 { get { return this.Shift(0xD); } }
            public V _1110 { get { return this.Shift(0xE); } }
            public V _1111 { get { return this.Shift(0xF); } }
            static public implicit operator V(ulong value)
            {
                return new V(value);
            }
            static public implicit operator ulong(V this_)
            {
                return this_.Value;
            }
            static public implicit operator uint(V this_)
            {
                return (uint)this_.Value;
            }
            static public implicit operator ushort(V this_)
            {
                return (ushort)this_.Value;
            }
            static public implicit operator byte(V this_)
            {
                return (byte)this_.Value;
            }
        }
    }
