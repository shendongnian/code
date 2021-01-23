    [ProtoBuf.ProtoMember(1)]
    private string[] LegacyData {get;set;}
    private bool LegacyDataSpecified { get { return false; } set { } }
    /* where 42 is just an unused new field number */
    [ProtoBuf.ProtoMember(42, Options = MemberSerializationOptions.Packed)]
    public ushort[] Data { get; set; }
    [ProtoBuf.ProtoAfterDeserialization]
    private void SerializationCallback()
    {
        if (LegacyData != null && LegacyData.Length > 0)
        {
            ushort[] parsed = Array.ConvertAll<string, ushort>(
                LegacyData, ushort.Parse);
            if (Data != null && Data.Length > 0)
            {
                int oldLen = parsed.Length;
                Array.Resize(ref parsed, parsed.Length + Data.Length);
                Array.Copy(Data, 0, parsed, oldLen, Data.Length);
            }
            Data = parsed;
        }
        LegacyData = null;
    }
