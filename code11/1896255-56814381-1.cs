    using System.Buffers.Binary;
    if (!BitConverter.IsLittleEndian)
    {
        value = BinaryPrimitives.ReverseEndianness(value);
    }
