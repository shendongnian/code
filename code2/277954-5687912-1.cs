        if (tempDraw != null)
        {
            tempDraw = (Bitmap)snapshot.Clone();
            
            using (Graphics g = Graphics.FromImage(tempDraw))
            using (Pen myPen = new Pen(colorPickerDropDown1.SelectedColor, 5))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                g.DrawLine(myPen, pDau, pHientai);
                e.Graphics.Clear(this.BackColor); // clear any drawing on the form
                e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
            }
        }
