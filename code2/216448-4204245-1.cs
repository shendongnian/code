          static public System.Drawing.Color GetPixelColor(int x, int y)
          {
           IntPtr hdc = GetDC(IntPtr.Zero);
           uint pixel = GetPixel(hdc, x, y);
           ReleaseDC(IntPtr.Zero, hdc);
           Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                        (int)(pixel & 0x0000FF00) >> 8,
                        (int)(pixel & 0x00FF0000) >> 16);
           return color;
          }
