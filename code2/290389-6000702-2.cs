        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Drawing vertical lines
            for (int x = 5; x < this.ClientRectangle.Width; x+=5)
            {
                e.Graphics.DrawLine(Pens.Gray, new Point(x, 0), new Point(x, this.ClientRectangle.Height));
            }
            // Drawing horisontal lines
            for (int y = 5; y < this.ClientRectangle.Width; y += 5)
            {
                e.Graphics.DrawLine(Pens.Gray, new Point(0, y), new Point(this.ClientRectangle.Width,y));
            }
        }
