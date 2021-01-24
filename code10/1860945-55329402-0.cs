    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        // This code defines a graphics shape using a GraphicsPath
        // and draws multiple copies along a grid and with various
        // rotation angle angles.
        e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;
        var target = sender as PictureBox;
        // Step 1 - Define a rectangle 20 by 12 pixels, center at origin.
        var gp = new GraphicsPath();
        gp.AddLines(new PointF[] {
            new PointF(-10, -6),
            new PointF( 10, -6),
            new PointF( 10,  6),
            new PointF(-10,  6) });
        gp.CloseFigure();
        // Step 2 - Define a 10×9 grid with two loops
        float angle = 0;
        for (int i = 0; i<9; i++)
        {
            // divide the control height into 10 divisions
            float y = (i+1)*target.Height/10;
            for (int j = 0; j<10; j++)
            {
                // divide the control width into 11 divisions
                float x = (j+1)*target.Width/11;
                // Save the default transformation state
                var state = e.Graphics.Save();
                // Traslate the origin to (x,y), each grid point
                e.Graphics.TranslateTransform(x, y);
                // Rotate shape by an angle (negative = CCW)
                e.Graphics.RotateTransform(-angle);
                // Draw the shape
                e.Graphics.FillPath(Brushes.LightSeaGreen, gp);
                e.Graphics.DrawPath(Pens.Black, gp);
                // Restore the default transformation state
                e.Graphics.Restore(state);
                // Increment the angle by one degree. 
                // The idea is to show all 90 degrees of rotation in a 10×9 grid.
                angle++;
            }
        }
    }
