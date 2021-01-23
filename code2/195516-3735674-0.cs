        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Pen pen = Pens.Red;
            // draw two vertical line
            e.Graphics.DrawLine(pen, new Point(100, 100), new Point(100, 200));
            e.Graphics.DrawLine(pen, new Point(103, 100), new Point(103, 200));
            // draw a line exactly in the middle of those two lines
            e.Graphics.DrawLine(pen, new PointF(101.5f, 200.0f), new PointF(101.5f, 300.0f)); ;
        }
