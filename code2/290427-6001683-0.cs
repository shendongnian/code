        public void DrawControl(Control control,Bitmap bitmap)
        {
            control.DrawToBitmap(bitmap,control.Bounds);
            foreach (Control childControl in control.Controls)
            {
                DrawControl(childControl,bitmap);
            }
        }
 
        public void SaveBitmap()
        {
            Bitmap bmp = new Bitmap(this.panel1.Width, this.panel.Height);
            this.panel.DrawToBitmap(bmp, new Rectangle(0, 0, this.panel.Width, this.panel.Height));
            foreach (Control control in panel1.Controls)
            {
                DrawControl(control, bmp);
            }
            bmp.Save("d:\\panel.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
