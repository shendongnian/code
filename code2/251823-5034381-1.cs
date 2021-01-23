    Bitmap b = new Bitmap(control.Width, control.Height);
    using (Graphics g = Graphics.FromImage(b)) {
       g.CopyFromScreen(control.Parent.RectangleToScreen(control.Bounds).X, 
          control.Parent.RectangleToScreen(control.Bounds).Y, 0, 0, 
          new Size(control.Bounds.Width, control.Bounds.Height),
          CopyPixelOperation.SourceCopy);
    }
    Bitmap output = new Bitmap(newWidth, newHeight);
    using (Graphics g = Graphics.FromImage(output)) {
      g.DrawImage(b, 0,0,newWidth, newHeight);
    }
