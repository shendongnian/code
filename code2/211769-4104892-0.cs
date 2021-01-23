            private void button1_Click(object sender, EventArgs e)
        {
            mLastRect++;
            if (mLastRect > 9)
                mLastRect = 0;
            Bitmap part = new Bitmap(pictureBox1.Image.Width / 3, pictureBox1.Image.Height / 3);
            Graphics g = Graphics.FromImage(part);
            Rectangle partRect = new Rectangle(0, 0, part.Width, part.Height);
            Rectangle sourceRect = GetRect(mLastRect);
            g.DrawImage(pictureBox1.Image, partRect, sourceRect, GraphicsUnit.Pixel);
            pictureBox2.Image = part;
        }
        private Rectangle GetRect(int rectNo)
        {
            int rectLeft = (rectNo % 3) * (pictureBox1.Image.Width / 3);
            int rectTop = (rectNo / 3) * (pictureBox1.Image.Height / 3);
            return new Rectangle(rectLeft, rectTop, pictureBox1.Image.Width / 3, pictureBox1.Image.Height / 3);
        }
