        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (var g = e.Graphics)
            {
                g.FillRectangle (Brushes.Black , new Rectangle(50, 50, 1, 1));
            }
        }
