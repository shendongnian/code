    using System.Drawing;
    using System.Drawing.Drawing2D;
    var myPoint = new PointF(10, 10);
    var transform = new Matrix();
    transform.Rotate(90.0f);
    transform.Shear(5, 0);
    var transformed = new PointF[] { myPoint };
    transform.TransformPoints(transformed);
