    public static sbyte ConvertTo2Complement(byte b)
    {
        if(b < 128)
        {
            return Convert.ToSByte(b);
        }
        else
        {
            int x = Convert.ToInt32(b);
            return Convert.ToSByte(x - 256);
        }
    }
            
