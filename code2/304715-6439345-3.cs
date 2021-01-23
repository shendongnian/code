    System.Text.StringBuilder s = new System.Text.StringBuilder();
    foreach (byte b in md5ByteArray)
    {
       s.Append(b.ToString("x2").ToLower());
    }
    password = s.ToString();
