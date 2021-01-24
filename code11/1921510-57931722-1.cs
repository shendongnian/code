    private Point _origLocation;
    public Bitmap _Bitmap;
    
    private void button1_Click(object sender, EventArgs e)
    {
       _Bitmap = new Bitmap(@"D:\Pleiades_large.jpg");
       SetTemp(new Point(0, 0));
    }
    
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e) 
       => _origLocation = e.Location;
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e) 
       => SetTemp(new Point(_origLocation.X - e.Location.X, _origLocation.Y - e.Location.Y));
    
    private void SetTemp(Point p)
    {
       if (MouseButtons != MouseButtons.Left) return;
    
       // Validate position
       if (p.X < 0) p.X = 0;
       if (p.Y < 0) p.Y = 0;
       if (p.X > _Bitmap.Width - pictureBox1.Width) p.X = _Bitmap.Width - pictureBox1.Width;
       if (p.Y > _Bitmap.Height - pictureBox1.Height) p.X = _Bitmap.Height - pictureBox1.Height;
    
       // Create temp image
       var target = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    
       using (var g = Graphics.FromImage(target))
       {
          g.DrawImage(
             _Bitmap, 
             new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height), 
             new Rectangle(p.X, p.Y, pictureBox1.Width, pictureBox1.Height), 
             GraphicsUnit.Pixel);
       }
    
       // Dispose and assign temp image 
       pictureBox1.Image?.Dispose();
       pictureBox1.Image = target;
    }
