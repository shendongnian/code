        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
            if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
            {
                Canvas.Refresh();
                using (Graphics g = Canvas.CreateGraphics())
                    g.FillRectangle(selectionBrush, Rect);
            }
        }
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (RectStartPoint == e.Location)
                {
                    Canvas.Refresh();
                }
            }
        }
        private void Canvas_Paint(object sender, PaintEventArgs e) { }
