    var secStr = new SecureString();
    foreach (byte b in decryptedBytes)
    {
        var c = (char)b;
        if ('\0' == c)
        {
            continue;
        }
        secStr.AppendChar(c);
    }
    return secStr;
