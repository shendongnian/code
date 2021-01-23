        private void saveButton_Click(object sender, EventArgs e)
        {
             int width = panel1.Size.Width;
             int height = panel1.Size.Height;
             using (Bitmap bmp = new Bitmap(width, height))
             {
                 panel1.DrawToBitmap(bmp, new Rectangle(0, 0, width, height));
                 bmp.Save(@"C:\testBMP.jpeg", ImageFormat.Jpeg);
             }
        }
