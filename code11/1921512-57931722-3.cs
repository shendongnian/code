    private Point _origLocation;
    public Bitmap _Bitmap;
    
    private void button1_Click(object sender, EventArgs e)
    {
       // create and store the original image, the one you are going to move around
       _Bitmap = new Bitmap(@"D:\Pleiades_large.jpg");
       // set it to 0,0
       SetTemp(new Point(0, 0));
    }
    
    // on mouse down capture the X/Y position so you know where to offset
    private void pictureBox1_MouseDown(object sender, MouseEventArgs e) 
       => _origLocation = e.Location;
    // when mouse moves do something
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e) 
       => SetTemp(new Point(_origLocation.X - e.Location.X, _origLocation.Y - e.Location.Y));
    
    private void SetTemp(Point p)
    {
       // if the mouse is not down, dont do anything
       if (MouseButtons != MouseButtons.Left) return;
    
       // Validate position, we cant move the image off the screen
       if (p.X < 0) p.X = 0;
       if (p.Y < 0) p.Y = 0;
       if (p.X > _Bitmap.Width - pictureBox1.Width) p.X = _Bitmap.Width - pictureBox1.Width;
       if (p.Y > _Bitmap.Height - pictureBox1.Height) p.X = _Bitmap.Height - pictureBox1.Height;
    
       // Create temp image, the size of the picture box
       var target = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    
       using (var g = Graphics.FromImage(target))
       {
          // crop the original image to the temp image
          // thats to say, where does it need to move
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
