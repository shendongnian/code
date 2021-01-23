	public static byte[] FromBase64Bytes(this byte[] base64Bytes)
	{
		string base64String = Encoding.UTF8.GetString(base64Bytes, 0, base64Bytes.Length);
		return Convert.FromBase64String(base64String);
	}
