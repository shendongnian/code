    public static byte[] ConvertToByteArray(string str, Encoding encoding)
    {
        return encoding.GetBytes(str);
    }
    
    public static String ToBinary(Byte[] data)
    {
        return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
    }
    
    // Use any sort of encoding you like. 
    var binaryString = ToBinary(ConvertToByteArray("Welcome, World!", Encoding.ASCII));
