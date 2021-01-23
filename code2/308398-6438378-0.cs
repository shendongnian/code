    static uint CalcCheckSum(byte[] data, int PECheckSum)
    {
        long checksum = 0;
        var top = Math.Pow(2, 32);
        for (var i = 0; i < data.Length / 4; i++)
        {
            if (i == PECheckSum / 4)
            {
                continue;
            }
            var dword = BitConverter.ToUInt32(data, i * 4);
            checksum = (checksum & 0xffffffff) + dword + (checksum >> 32);
            if (checksum > top)
            {
                checksum = (checksum & 0xffffffff) + (checksum >> 32);
            }
        }
        checksum = (checksum & 0xffff) + (checksum >> 16);
        checksum = (checksum) + (checksum >> 16);
        checksum = checksum & 0xffff;
        checksum += (uint)data.Length;
        return (uint)checksum;
    }
