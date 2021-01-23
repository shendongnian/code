    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
      int foundColor = _Mask.GetPixel(e.X, e.Y).ToArgb();
      if (foundColor == Color.Red.ToArgb())
        // do something with this bubble
      else if (foundColor == Color.Blue.ToArgb())
        // do something with this bubble
      else
        // do nothing
    }
