    String theString = "45 Degree Rotated Text";
    SizeF sz = e.Graphics.VisibleClipBounds.Size;
    //Offset the coordinate system so that point (0, 0) is at the
    center of the desired area.
    e.Graphics.TranslateTransform(sz.Width / 2, sz.Height / 2);
    //Rotate the Graphics object.
    e.Graphics.RotateTransform(45);
    sz = e.Graphics.MeasureString(theString, this.Font);
    //Offset the Drawstring method so that the center of the string matches the center.
    e.Graphics.DrawString(theString, this.Font, Brushes.Black, -(sz.Width/2), -(sz.Height/2));
    //Reset the graphics object Transformations.
    e.Graphics.ResetTransform();
