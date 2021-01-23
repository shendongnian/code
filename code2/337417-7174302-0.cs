       private Cursor crossCursor(Pen pen, Brush brush, string name, int x, int y) {
                var pic = new Bitmap(x, y);
                Graphics gr = Graphics.FromImage(pic);
    
                var pathX = new GraphicsPath();
                var pathY = new GraphicsPath();
                pathX.AddLine(0, y / 2, x, y / 2);
                pathY.AddLine(x / 2, 0, x / 2, y);
                gr.DrawPath(pen, pathX);
                gr.DrawPath(pen, pathY);
                gr.DrawString(name, Font, brush, x / 2 + 5, y - 35);
    
                IntPtr ptr = pic.GetHicon();
                var c = new Cursor(ptr);
                return c;
            }
