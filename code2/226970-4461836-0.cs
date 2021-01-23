            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            SizeF txt = e.Graphics.MeasureString(Text, this.Font);
            SizeF sz = e.Graphics.VisibleClipBounds.Size;            
            //90 degrees
            e.Graphics.TranslateTransform(sz.Width, 0);            
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString(Text, this.Font, Brushes.Black, new RectangleF(0, 0, sz.Height, sz.Width), format);
            e.Graphics.ResetTransform();                                    
            //180 degrees
            e.Graphics.TranslateTransform(sz.Width, sz.Height);
            e.Graphics.RotateTransform(180);
            e.Graphics.DrawString(Text, this.Font, Brushes.Black, new RectangleF(0, 0, sz.Width, sz.Height), format);
            e.Graphics.ResetTransform();            
            //270 degrees
            e.Graphics.TranslateTransform(0, sz.Height);
            e.Graphics.RotateTransform(270);
            e.Graphics.DrawString(Text, this.Font, Brushes.Black, new RectangleF(0, 0, sz.Height, sz.Width), format);
            e.Graphics.ResetTransform();
            //0 = 360 degrees
            e.Graphics.TranslateTransform(0, 0);
            e.Graphics.RotateTransform(0);
            e.Graphics.DrawString(Text, this.Font, Brushes.Black, new RectangleF(0, 0, sz.Width, sz.Height), format);
            e.Graphics.ResetTransform();
