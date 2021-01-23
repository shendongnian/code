       Graphics g = Graphics.FromImage(pictureBox1.Image);
       using (Pen pen = new Pen(Color.Red, 2))
          {
             if (paintDemoButtonSwitch == true)
             {
                g.DrawRectangle(pen, rectToDrawOut.X, rectToDrawOut.Y, rectToDrawOut.Width, rectToDrawOut.Height);
             }
       }
       pictureBox1.Image.Save(@"d:\testit.png", System.Drawing.Imaging.ImageFormat.Png);
