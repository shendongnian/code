            var bmp = new Bitmap(480, 480);
            using (var gr = Graphics.FromImage(bmp)) {
                gr.Clear(Color.White);
                TextRenderer.DrawText(gr, textBox1.Text, this.Font, 
                    new Rectangle(0, 0, bmp.Width, bmp.Height), 
                    Color.Black, Color.White,
                    TextFormatFlags.WordBreak | TextFormatFlags.Left);
            }
            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = bmp;
