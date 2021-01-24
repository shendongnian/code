 c#
    [StructLayout(LayoutKind.Explicit, Pack = 0, Size = 23)]
    public struct PacketHeader
    {
        public static PacketHeader Read(ReadOnlySpan<byte> bytes)
            => MemoryMarshal.Cast<byte, PacketHeader>(bytes)[0];
        public void Write(Span<byte> bytes)
            => MemoryMarshal.Cast<byte, PacketHeader>(bytes)[0] = this;
        [FieldOffset(0)]
        public ushort m_packetFormat;         // 2019
        [FieldOffset(2)]
        public byte m_gameMajorVersion;     // Game major version - "X.00"
        [FieldOffset(3)]
        public byte m_gameMinorVersion;     // Game minor version - "1.XX"
        [FieldOffset(4)]
        public byte m_packetVersion;        // Version of this packet type, all start from 1
        [FieldOffset(5)]
        public byte m_packetId;             // Identifier for the packet type, see below
        [FieldOffset(6)]
        public ulong m_sessionUID;           // Unique identifier for the session
        [FieldOffset(14)]
        public float m_sessionTime;          // Session timestamp
        [FieldOffset(18)]
        public uint m_frameIdentifier;      // Identifier for the frame the data was retrieved on
        [FieldOffset(22)]
        public byte m_playerCarIndex;       // Index of player's car in the array
    };
Note also the use of `MemoryMarshal` here which makes coercion a lot easier. `byte[]` can be treated as a span.
