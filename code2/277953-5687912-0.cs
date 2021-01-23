    private void Form_Paint(object sender, PaintEventArgs e)
    {
        if (tempDraw != null)
        {
            tempDraw = (Bitmap)snapshot.Clone();
            Graphics g = Graphics.FromImage(tempDraw);
            Pen myPen = new Pen(colorPickerDropDown1.SelectedColor, 5);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g.DrawLine(myPen, pDau, pHientai);
            myPen.Dispose();
            e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
            g.Dispose();
        }
    }
