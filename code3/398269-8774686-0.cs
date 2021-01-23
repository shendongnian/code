    // Create the triangle
    GraphicsPath p = new GraphicsPath();
    p.AddLine(triangleVertex1, triangleVertex2);
    p.AddLine(triangleVertex2, triangleVertex3);
    p.CloseFigure();
    
    // Draw the triangle
    Bitmap b = new Bitmap(pictureBox.ClientSize.Width, pictureBox.ClientSize.Height);
    
    using(Graphics g = Graphics.FromImage(b), TextureBrush t = new TextureBrush(myImage)) {
        g.FillPath(t, p);
    }
    
    // Finally, set the PictureBox's image
    pictureBox.Image = b;
