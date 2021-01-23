    public static class ByteExtensions
    {
        // Assume 0 is the MSB andd 7 is the LSB.
        public static bool GetBit(this byte byt, int index)
        {
            if (index < 0 || index > 7)
                throw new ArgumentOutOfRangeException();
            int shift = 7 - index;
            // Get a single bit in the proper position.
            byte bitMask = (byte)(1 << shift);
            // Mask out the appropriate bit.
            byte masked = (byte)(byt & bitMask);
            // If masked != 0, then the masked out bit is 1.
            // Otherwise, masked will be 0.
            return masked != 0;
        }
    }
