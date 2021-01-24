c#
private uint CalculateBlockCheckSum(uint u32Sum, byte[] blockImage)
{
    uint u32Word;
    ulong u64Sum = u32Sum;
    ulong comparisonValue = 0x100000000;
    int count = blockImage.Length / sizeof(uint);
    int i = 0;
    while (count-- > 0)
    {
        u32Word = BitConverter.ToUInt32(blockImage,i*sizeof(uint));
        u64Sum ^= u32Word;
        for (byte iCounter = 0; iCounter < (8 * 4); ++iCounter)
        {
            u64Sum <<= 1;
            if ((u64Sum & comparisonValue) != 0)
            {
                u64Sum ^= 0x04C11DB7uL;
            }
        }
        i++;
    }
    return (uint)u64Sum;
}
