    private void pictureBox1_Click(object sender, EventArgs e)
            {
                if ((Color)pictureBox1.Tag == Color.Red) { pictureBox1.Tag = Color.Blue; }
                else {pictureBox1.Tag = Color.Red; }
                pictureBox1.Refresh();
            }
