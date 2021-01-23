    String str = string.Format("Failed statistics read, device {0}", device);
    byte[] dataBuffer = System.Text.Encoding.ASCII.GetBytes(str);
    // for 2-byte unicode
    byte[] dataBuffer = System.Text.Encoding.Unicode.GetBytes(str);
    // for UTF8 unicode
    byte[] dataBuffer = System.Text.Encoding.UTF8.GetBytes(str);
