    public byte[] ConvertToByteArray(IList<ArraySegment<byte>> list)
    {
        var bytes = new byte[list.Sum (asb => asb.Count)];
        int pos = 0;
        foreach (var asb in list)
            Buffer.BlockCopy (asb.Array, asb.Offset, bytes, pos += asb.Count, asb.Count);
        return bytes;
    }
