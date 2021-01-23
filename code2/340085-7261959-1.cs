    //fixed
    [DllImport("user32.dll", SetLastError = true)] static extern bool DestroyIcon(IntPtr hIcon);
           public Icon MakeRandomIcon()
           {
               using (Bitmap bmp = new Bitmap(size, size))
               using (Graphics g = Graphics.FromImage(bmp))
               {
                   for (int it = 0; it < 20; it++) this.GetRandomPainter()(g);
                   g.Dispose();
                   IntPtr hIcon = bmp.GetHicon();
                   Icon temp = Icon.FromHandle(hIcon);
                   Icon ico = (Icon)temp.Clone();
                   temp.Dispose();
                   DestroyIcon(hIcon);
                   return ico;
               }
           }
    
    
    //thanks Miguel again.
