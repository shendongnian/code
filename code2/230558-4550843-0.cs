    // Get hold of your graphics context...
    using(Graphics g = this.CreateGraphics())
    {
        // When drawing we want to apply a scaling of 2,2 (making it bigger!)
        Matrix m = new Matrix();
        m.Scale(2, 2, MatrixOrder.Append);
        g.Transform = m;
        // Draw the actual image using the assigned matrix transform
        g.DrawImage(...);        
    }
