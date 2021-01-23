    byte[] bytes = Encoding.UTF32.GetBytes(abc);
    
    int codePointCount = bytes.Length / 4;
    
    int[] codePoints = new int[codePointCount];
    
    for (int i = 0; i < codePointCount; i++)
    	codePoints[i] = BitConverter.ToInt32(bytes, i * 4);
