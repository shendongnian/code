            pictureBox1.Image = Image.FromFile("picture\\faces\\face3.png");
            Bitmap bmp = new Bitmap(pictureBox1.Image);
            Console.WriteLine(bmp.Width);
            Graphics g = Graphics.FromImage(bmp);
            pictureBox1.Image = Image.FromFile("picture\\faces\\eyebow1.png");
            g.DrawImage(new Bitmap(pictureBox1.Image), new Point(0, 0));
            
            g.Dispose();
            pictureBox1.Image = bmp;
