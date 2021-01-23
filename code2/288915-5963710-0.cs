            System.Drawing.Graphics g = mypanel.CreateGraphics();
    g.DrawImage(Image.FromFile("MyImage.jpg"), new Point(10, 10));
            System.Drawing.BufferedGraphicsContext dc = new BufferedGraphicsContext();
            BufferedGraphics backbuffer = dc.Allocate(g,new Rectangle(new Point(0,0),g.ClipBounds.Size.ToSize()));
            backbuffer.Render(this.CreateGraphics());
