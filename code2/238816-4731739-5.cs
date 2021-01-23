    public static byte[] ToUtf8(this string str)
    {
      return Encoding.UTF8.GetBytes(str);
    }
    public static byte[] ToAscii(this string str)
    {
      return Encoding.ASCII.GetBytes(str);
    }
    public static string ToBase64(this byte[] bytes)
    {
      return Convert.ToBase64String(bytes);
    }
