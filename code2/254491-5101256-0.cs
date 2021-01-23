    int lineSize = bData.Width * 3;
    int byteCount = lineSize * bData.Height;
    byte[] bmpBytes = new byte[byteCount];
    IntPtr scan = bData.Scan0;
    for (int i = 0; i < bData.Height; i++) {
      Marshal.Copy(scan, bmpBytes[i * lineSize], 0, lineSize);
      scan += bData.Stride;
    }
