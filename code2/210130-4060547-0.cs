        Point startPos;      // mouse-down position
        Point currentPos;    // current mouse position
        bool drawing;        // busy drawing
        List<Rectangle> rectangles = new List<Rectangle>();  // previous rectangles
        private Rectangle getRectangle() {
            return new Rectangle(
                Math.Min(startPos.X, currentPos.X),
                Math.Min(startPos.Y, currentPos.Y),
                Math.Abs(startPos.X - currentPos.X),
                Math.Abs(startPos.Y - currentPos.Y));
        }
        private void canevas_MouseDown(object sender, MouseEventArgs e) {
            currentPos = startPos = e.Location;
            drawing = true;
        }
        private void canevas_MouseMove(object sender, MouseEventArgs e) {
            currentPos = e.Location;
            if (drawing) canevas.Invalidate();
        }
        private void canevas_MouseUp(object sender, MouseEventArgs e) {
            if (drawing) {
                drawing = false;
                var rc = getRectangle();
                if (rc.Width > 0 && rc.Height > 0) rectangles.Add(rc);
                canevas.Invalidate();
            }
        }
        private void canevas_Paint(object sender, PaintEventArgs e) {
            if (rectangles.Count > 0) e.Graphics.DrawRectangles(Pens.Black, rectangles.ToArray());
            if (drawing) e.Graphics.DrawRectangle(Pens.Red, getRectangle());
        }
