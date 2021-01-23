    byteArray = ms.ToArray();
    System.Text.StringBuilder sB = new System.Text.StringBuilder(byteArray.Length);
    foreach (byte item in byteArray)
    {
        sB.Append((char)item);
    }
