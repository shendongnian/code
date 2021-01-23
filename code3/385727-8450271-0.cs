    public static void ShiftLeft(ref byte[] bytes)
    {
        for (int index = 0; index < bytes.Length; index++)
        {
            int workRegister = (int)bytes[index];
            workRegister = workRegister << 1;
            bytes[index] = (byte)workRegister;
            if (index > 0)
            {
                byte carry = (byte)(workRegister >> 8);
                bytes[index - 1] = (byte)(bytes[index - 1] | carry);
            }
         }
    }
    public static void ShiftRight(ref byte[] bytes)
    {
        int rightEnd = bytes.Length - 1;
        for (int index = rightEnd; index >= 0; index--)
        {
            int workRegister = (int)bytes[index];
            bytes[index] = (byte)(bytes[index] >> 1);
			
            if (index < rightEnd)
            {
                byte carry = (byte)(workRegister << 8 >> 1);
                bytes[index + 1] = (byte)(bytes[index + 1] | carry);
            }
        }
    }
