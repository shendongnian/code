    private void Scale_Click(object sender,
      System.EventArgs e)
    {
        // Create Graphics object
        Graphics g = this.CreateGraphics();
        g.Clear(this.BackColor);
        // Draw a filled rectangle with
        // width 20 and height 30
        g.FillRectangle(Brushes.Blue,
            20, 20, 20, 30);
        // Create Matrix object
        Matrix X = new Matrix();
        // Apply 3X scaling
        X.Scale(3, 4, MatrixOrder.Append);
        // Apply transformation on the form
        g.Transform = X;
        // Draw a filled rectangle with
        // width 20 and height 30
        g.FillRectangle(Brushes.Blue,
            20, 20, 20, 30);
        // Dispose of object
        g.Dispose();
    }
