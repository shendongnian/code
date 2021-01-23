    /// <summary>
    /// Rotates the bits in an array of bytes to the left.
    /// </summary>
    /// <param name="bytes">The byte array to rotate.</param>
    public static void RotateLeft(ref byte[] bytes)
    {
        bool carryFlag = ShiftLeft(ref bytes);
        
        if (carryFlag == true)
        {
            bytes[bytes.Length - 1] = (byte)(bytes[bytes.Length - 1] | 0x01);
        }
    }
    
    /// <summary>
    /// Rotates the bits in an array of bytes to the right.
    /// </summary>
    /// <param name="bytes">The byte array to rotate.</param>
    public static void RotateRight(ref byte[] bytes)
    {
        bool carryFlag = ShiftRight(ref bytes);
        
        if (carryFlag == true)
        {
            bytes[0] = (byte)(bytes[0] | 0x80);
        }
    }
    
    /// <summary>
    /// Shifts the bits in an array of bytes to the left.
    /// </summary>
    /// <param name="bytes">The byte array to shift.</param>
    public static bool ShiftLeft(ref byte[] bytes)
    {
        bool leftMostCarryFlag = false;
        // Iterate through the elements of the array from left to right.
        for (int index = 0; index < bytes.Length; index++)
        {
            // If the leftmost bit of the current byte is 1 then we have a carry.
            bool carryFlag = (bytes[index] & 0x80) > 0;
            if (index > 0)
            {
                if (carryFlag == true)
                {
                    // Apply the carry to the rightmost bit of the current bytes neighbor to the left.
                    bytes[index - 1] = (byte)(bytes[index - 1] | 0x01);
                }
            }
            else
            {
                leftMostCarryFlag = carryFlag;
            }
            bytes[index] = (byte)(bytes[index] << 1);
        }
        
        return leftMostCarryFlag;
    }
    /// <summary>
    /// Shifts the bits in an array of bytes to the right.
    /// </summary>
    /// <param name="bytes">The byte array to shift.</param>
    public static bool ShiftRight(ref byte[] bytes) 
    {
        bool rightMostCarryFlag = false;
        int rightEnd = bytes.Length - 1;
        
        // Iterate through the elements of the array right to left.
        for (int index = rightEnd; index >= 0; index--)
        {
            // If the rightmost bit of the current byte is 1 then we have a carry.
            bool carryFlag = (bytes[index] & 0x01) > 0;
            if (index < rightEnd)
            {
                if (carryFlag == true)
                {
                    // Apply the carry to the leftmost bit of the current bytes neighbor to the right.
                    bytes[index + 1] = (byte)(bytes[index + 1] | 0x80);
                }
            }
            else
            {
                rightMostCarryFlag = carryFlag;
            }
            bytes[index] = (byte)(bytes[index] >> 1);
        }
        
        return rightMostCarryFlag;
    } 
