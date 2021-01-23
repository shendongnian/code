    [StructLayout(LayoutKind.Sequential)]    
    private struct ICONINFO
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }
    
    [DllImport("user32")]
    private static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO pIconInfo);
    
    [DllImport("user32.dll")]
    private static extern IntPtr LoadCursorFromFile(string lpFileName);
    [DllImport("gdi32.dll", SetLastError = true)]
    private static extern bool DeleteObject(IntPtr hObject);
    
    private Bitmap BitmapFromCursor(Cursor cur)
    {
        ICONINFO ii;
        GetIconInfo(cur.Handle, out ii);
    
        Bitmap bmp = Bitmap.FromHbitmap(ii.hbmColor);
        DeleteObject(ii.hbmColor);
        DeleteObject(ii.hbmMask);
    
        BitmapData bmData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
        Bitmap dstBitmap = new Bitmap(bmData.Width, bmData.Height, bmData.Stride, PixelFormat.Format32bppArgb, bmData.Scan0);
        bmp.UnlockBits(bmData);
    
        return new Bitmap(dstBitmap);
    }
    
    private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
        //Using LoadCursorFromFile from user32.dll, get a handle to the icon
        IntPtr hCursor = LoadCursorFromFile("C:\\Windows\\Cursors\\Windows Aero\\aero_busy.ani");
    
        //Create a Cursor object from that handle
        Cursor cursor = new Cursor(hCursor);
    
        //Convert that cursor into a bitmap
        using (Bitmap cursorBitmap = BitmapFromCursor(cursor))
        {
            //Draw that cursor bitmap directly to the form canvas
            e.Graphics.DrawImage(cursorBitmap, 50, 50);
        }
    }
