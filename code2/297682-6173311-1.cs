    private byte[] ToByteArray(Stream stream, System.Text.Encoding encoding)
    {
        using(var sr = new StreamReader(stream, encoding))
    	{
    		return encoding.GetBytes(sr.ReadToEnd());
    	}
    }
