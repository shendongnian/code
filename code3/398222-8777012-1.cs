    byte[] buffer = new byte[1024];
    int iRx = soc.Receive(buffer);
    char[] chars = new char[iRx];
    
    System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
    int charLen = d.GetChars(buffer, 0, iRx, chars, 0);
    System.String recv = new System.String(chars);
