    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        // get the Graphics object of the form.
        Graphics g = e.Graphics;
        // create a think red pen for the circle drawing
        Pen redPen = new Pen(Brushes.Red, 4.0f);
        // drawing the circle
        PointF ctrlCenter = GetCenterOfControl(CircleCenter);
        g.DrawEllipse(redPen,
                ctrlCenter.X - (Diameter / 2),
                ctrlCenter.Y - (Diameter / 2),
                Diameter, Diameter);
    }
    //The following little method to calculate the center point
    PointF GetCenterOfControl(Control ctrl)
    {
        return new PointF(ctrl.Left + (ctrl.Width / 2),
                ctrl.Top + (ctrl.Height / 2));
    }
