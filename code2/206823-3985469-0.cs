        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {    
            if (e.Index == -1)
            {
                return;
            }
            using (Bitmap drawbuffer = new Bitmap(e.Bounds.Width, e.Bounds.Height))
            {
                using (Graphics grfx = Graphics.FromImage(drawbuffer))
                {
                    grfx.FillRectangle(mWhiteBrush, 0, 0, e.Bounds.Width, e.Bounds.Height);
                    ColorInfo colorInfo = (ColorInfo)Items[e.Index];
                    Color brushColor = colorInfo.Color;
                    using (SolidBrush brush = new SolidBrush(brushColor))
                    {
                        Rectangle rectangleColor = new Rectangle();
                        Rectangle rectangleText = new Rectangle();
                        rectangleColor.Height = rectangleColor.Width = e.Bounds.Height;
                        rectangleText.X += rectangleColor.Width;
                        rectangleText.Width = e.Bounds.Width - e.Bounds.Height;
                        grfx.FillRectangle(brush, rectangleColor);
                        grfx.DrawString(colorInfo.Name, e.Font, mBlackBrush, rectangleText);
                    }
                    e.Graphics.DrawImageUnscaled(drawbuffer, e.Bounds);
                }
            }
        }
