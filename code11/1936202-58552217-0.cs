    public void GrabRect(Rectangle rect)
        {
            int rectWidth = rect.Width - rect.Left;
            int rectHeight = rect.Height - rect.Top;
            Bitmap bm = new Bitmap(rectWidth, rectHeight);
            Graphics g = Graphics.FromImage(bm);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, new Size(rectWidth, rectHeight));
            this.pb_screengrab.Image = bm;
            Clipboard.SetImage(bm);
            g.Dispose();
        }
