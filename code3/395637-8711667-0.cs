    string mask = "255.255.128.0";
    int totalBits = 0;
    foreach (string octet in mask.Split('.'))
    {
        byte octetByte = byte.Parse(octet);
        while (octetByte != 0)
        {
            totalBits += octetByte & 1;     // logical AND on the LSB
            octetByte >>= 1;            // do a bitwise shift to the right to create a new LSB
        }                
    }
    Console.WriteLine(totalBits);
