    ulong x = 0x0A0B0C;
    Console.WriteLine(x.ToString("X6"));
    // We're only interested in last 2 Bytes:
    ulong x2 = x & 0xFFFF;
    // Now let's get those last 2 bytes:
    byte upperByte = (byte)(x2 >> 8); // Shift 8 bytes -> tell get dropped
    Console.WriteLine(upperByte.ToString("X2"));
    byte lowerByte = (byte)(x2 & 0xFF); // Only last Byte is left
    Console.WriteLine(lowerByte.ToString("X2"));
    // The question is: What do you want to do with it? Switch or leave it in this order?
    // leave them in the current order:
    Console.WriteLine(BitConverter.ToString(new byte[] { upperByte, lowerByte }));
    // switch positions:
    Console.WriteLine(BitConverter.ToString(new byte[] { lowerByte, upperByte }));
