    oby.Add(Convert.ToByte(0x1B));
    oby.Add(Convert.ToByte(0x2A));
    oby.Add(Convert.ToByte(33));
    oby.Add(Convert.ToByte(ImageWidth & 0xFF));
    oby.Add(Convert.ToByte((ImageWidth & 0xFF00)>>8));
    Bytes = PrintExtensions.AddBytes(Bytes, oby.ToArray());
