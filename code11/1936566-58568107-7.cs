    // Convert string of binary value (base 2) to byte
    byte v1 = Convert.ToByte("00000010", 2);
    byte v2 = Convert.ToByte("11110100", 2);
    // Operate bits
    v1 = (byte)( v1 | 0b10000000 );
    v1 = (byte)( v1 | ( v2 & 0b10000000 ) >> 7 );
    v2 = (byte)( v2 & ~0b10000000 );
    // Convert to string formatted
    string result1 = Convert.ToString(v1, 2).PadLeft(8, '0');
    string result2 = Convert.ToString(v2, 2).PadLeft(8, '0');
    Console.WriteLine(result1);
    Console.WriteLine(result2);
