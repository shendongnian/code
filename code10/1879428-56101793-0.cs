    byte[] oldBytes = new byte[] { 0x46, 0x52, 0x49, 0x53, 0x43, 0x48,
        0x4B, 0xEF, 0xBF, 0xBD, 0x53, 0x45, 0x5A, 0x55, 0x42, 0x45, 0x52,
        0x45, 0x49, 0x54, 0x55, 0x4E, 0x47, 0x45, 0x4E, 0x20, 0x20 };
    Console.WriteLine($"oldBytes: {BitConverter.ToString(oldBytes)} ({oldBytes.Length})");
    string oldStr = Encoding.UTF8.GetString(oldBytes);
    Console.WriteLine($"oldStr: <{oldStr}>");
    byte[] newBytes = Encoding.GetEncoding("ISO-8859-1").GetBytes(oldStr);
    Console.WriteLine($"newBytes: {BitConverter.ToString(newBytes)} ({newBytes.Length})");
    string newStr = Encoding.GetEncoding("ISO-8859-1").GetString(newBytes);
    Console.WriteLine($"newStr: <{newStr}>");
