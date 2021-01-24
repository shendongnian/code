        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int halfWidth = pictureBox1.Width / 2;
            e.Graphics.DrawImage(image1, new Rectangle(0, 0, halfWidth, pictureBox1.Height));
            e.Graphics.DrawImage(image2, new Rectangle(halfWidth + 1, 0, halfWidth, pictureBox1.Height));
            e.Graphics.DrawLine(Pens.Black, 140, 140, 300, 300);
        }
