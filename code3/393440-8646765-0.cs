     Bitmap _b;
     private void Form1_Paint(object sender, PaintEventArgs e)
     {
        _b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        Graphics g = Graphics.FromImage(_b);
        g.DrawEllipse(Pens.Black,new Rectangle(0,0,25,25));
        pictureBox1.Image = _b;
     }
     ...
     private void ParseImage()
     {
        for (int y = 0; y < _b.Height; y++)
        {
           for (int x = 0; x < _b.Width; x++)
           {
              Color c = _b.GetPixel(x, y);
           }
         }
      }
