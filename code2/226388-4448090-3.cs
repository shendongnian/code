        bool holdsImage = false;
        Control currentControl = null;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            holdsImage = true;           
        }
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            currentControl = pictureBox2;
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            currentControl = null;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (holdsImage && currentControl==pictureBox2)
            {
                pictureBox2.Image = pictureBox1.Image;
                pictureBox1.Image = null;
            }
            holdsImage = false;
            currentControl = null;
        }
