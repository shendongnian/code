/// <summary>
/// Takes in content bounds, and returns the bounds of the rendered
/// output of that content after the Effect is applied.
/// </summary>
internal override Rect GetRenderBounds(Rect contentBounds)
{
    Point topLeft = new Point();
    Point bottomRight = new Point();
 
    double radius = BlurRadius;
    topLeft.X = contentBounds.TopLeft.X - radius;
    topLeft.Y = contentBounds.TopLeft.Y - radius;
    bottomRight.X = contentBounds.BottomRight.X + radius;
    bottomRight.Y = contentBounds.BottomRight.Y + radius;
 
    double depth = ShadowDepth;
    double direction = Math.PI/180 * Direction;
    double offsetX = depth * Math.Cos(direction);
    double offsetY = depth * Math.Sin(direction);
 
    // If the shadow is horizontally aligned or to the right of the original element...
    if (offsetX >= 0.0f)
    {
        bottomRight.X += offsetX;
    }
    // If the shadow is to the left of the original element...
    else
    {
        topLeft.X += offsetX;
    }
 
    // If the shadow is above the original element...
    if (offsetY >= 0.0f)
    {
        topLeft.Y -= offsetY;
    }
    // If the shadow is below the original element...
    else 
    {
        bottomRight.Y -= offsetY;
    }
 
    return new Rect(topLeft, bottomRight);
}
I hope this helps.
Update from the author of the question
-----------------
Here's the actual code that I'm using:
    //Draws image with shadow.
    using (var drawingContext = drawingVisual.RenderOpen())
    {
        //Measure drop shadow space.
        var point1 = new Point(0 - model.BlurRadius / 2d, 0 - model.BlurRadius / 2d);
        var point2 = new Point(image.PixelWidth + model.BlurRadius / 2d, image.PixelHeight + model.BlurRadius / 2d);
       var num1 = Math.PI / 180.0 * model.Direction;
       var num2 = model.Depth * Math.Cos(num1);
       var num3 = model.Depth * Math.Sin(num1);
       if (num2 >= 0.0)
           point2.X += num2; //If the shadow is horizontally aligned or to the right of the original element...
       else
           point1.X += num2; //If the shadow is to the left of the original element...
       if (num3 >= 0.0)
           point1.Y -= num3; //If the shadow is above the original element...
       else
           point2.Y -= num3; //If the shadow is below the original element...
       var left = Math.Abs(point1.X);
       var top = Math.Abs(point1.Y);
       var totalWidth = left + point2.X;
       var totalHeight = top + point2.Y;
       //Image.
       drawingContext.DrawImage(image, new Rect((int)left, (int)top, image.PixelWidth, image.PixelHeight));
       frameHeight = (int)totalHeight;
       frameWidth = (int)totalWidth;
    }
