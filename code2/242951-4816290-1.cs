    var packet = new byte[] {
                                0x0C, 0x00, 0xE2, 0x66, 0x65, 0x47,
                                0x4E, 0x09, 0x04, 0x13, 0x65, 0x00
                            };
    CryptPacket(packet);
    // displays "....../here." where "." represents an unprintable character
    Console.WriteLine(Encoding.ASCII.GetString(packet));
    // ...
    void CryptPacket(byte[] packet)
    {
        int paksize = (packet[0] | (packet[1] << 8)) - 2;
        for (int i = 2; i < paksize; i++)
        {
            packet[i] ^= 0x61;
        }
    }
