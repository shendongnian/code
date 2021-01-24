        [StructLayout(LayoutKind.Explicit, Size = 128)]
        struct Message
        {
            [FieldOffset(0)]
            public byte[] data;
            [FieldOffset(0)]
            public Int16 Type;
            [FieldOffset(2)]
            public byte Number;
            [FieldOffset(3)]
            public byte PayloadSize;
            [FieldOffset(4)]
            public Int16 type;
            [FieldOffset(6)]
            public byte[] Payload;
            [FieldOffset(126)]
            public Int16 CheckSum;
        }
