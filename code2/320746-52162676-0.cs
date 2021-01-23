    private Bitmap CaptureScreen()
    {
        // Size size is how big an area to capture
        // pointOrigin is the upper left corner of the area to capture
        int width = Screen.PrimaryScreen.Bounds.X + Screen.PrimaryScreen.Bounds.Width;
        int height = Screen.PrimaryScreen.Bounds.Y + Screen.PrimaryScreen.Bounds.Height;
        Size size = new Size(width, height);
        Point pointOfOrigin = new Point(0, 0);
        Bitmap bitmap = new Bitmap(size.Width, size.Height);
        {
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(pointOfOrigin, new Point(0, 0), size);
                //Following code is all you needed!
                graphics.DrawIcon(new Icon("Sample.ico"),Cursor.Position.X-50,Cursor.Position.Y-50);
                //The reason I minus 50 in the position is because you need to "offset" the position. Please go check out the post WholsRich commented.
            }
            return bitmap;
        }
    }
