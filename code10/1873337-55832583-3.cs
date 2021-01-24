        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // possibly other drawing operations
            e.Graphics.ResetTransform();
            e.Graphics.TranslateTransform(10, 10);
            e.Graphics.ScaleTransform(scale, scale);
            e.Graphics.TranslateTransform(-10, -10);
            e.Graphics.DrawPath(Pens.Red, path);
            e.Graphics.ResetTransform();
            // possibly other drawing operations
        }
