        private int X;
        private int Y;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("X: {0} Y: {1}", X, Y));
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
        }
