C#
/// <summary>
/// Adding a set of predefined markers which could be used to highlight positions in an image
/// <summary>
private void DrawMarker(IInputOutputArray img, Point position, MCvScalar color, MarkerType markerType, int markerSize, int thickness, LineType line_type)
{
    switch (markerType)
    {
        // The cross marker case
        case MarkerType.MarkerCross:
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y), new Point(position.X + markerSize / 2, position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y - markerSize / 2), new Point(position.X, position.Y + markerSize / 2), color, thickness, line_type);
            break;
        // The tilted cross marker case
        case MarkerType.MarkerTiltedCross:
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y - markerSize / 2), new Point(position.X + markerSize / 2, position.Y + markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + markerSize / 2, position.Y - markerSize / 2), new Point(position.X - markerSize / 2, position.Y + markerSize / 2), color, thickness, line_type);
            break;
        // The star marker case
        case MarkerType.MarkerStar:
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y), new Point(position.X + markerSize / 2, position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y - markerSize / 2), new Point(position.X, position.Y + markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y - markerSize / 2), new Point(position.X + markerSize / 2, position.Y + markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + markerSize / 2, position.Y - markerSize / 2), new Point(position.X - markerSize / 2, position.Y + markerSize / 2), color, thickness, line_type);
            break;
        // The diamond marker case
        case MarkerType.MarkerDiamond:
            CvInvoke.Line(img, new Point(position.X, position.Y - markerSize / 2), new Point(position.X + markerSize / 2, position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + markerSize / 2, position.Y), new Point(position.X, position.Y + markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y + markerSize / 2), new Point(position.X - markerSize / 2, position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y), new Point(position.X, position.Y - markerSize / 2), color, thickness, line_type);
            break;
        // The square marker case
        case MarkerType.MarkerSquare:
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y - markerSize / 2), new Point(position.X + markerSize / 2, position.Y - markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + markerSize / 2, position.Y - markerSize / 2), new Point(position.X + markerSize / 2, position.Y + markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + markerSize / 2, position.Y + markerSize / 2), new Point(position.X - markerSize / 2, position.Y + markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y + markerSize / 2), new Point(position.X - markerSize / 2, position.Y - markerSize / 2), color, thickness, line_type);
            break;
        // The triangle up marker case
        case MarkerType.MarkerTriangleUp:
            CvInvoke.Line(img, new Point(position.X - markerSize / 2, position.Y + markerSize / 2), new Point(position.X + markerSize / 2, position.Y + markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + markerSize / 2, position.Y + markerSize / 2), new Point(position.X, position.Y - markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y - markerSize / 2), new Point(position.X - markerSize / 2, position.Y + markerSize / 2), color, thickness, line_type);
            break;
        // The triangle down marker case
        case MarkerType.MarkerTriangleDown:
            CvInvoke.Line(img, new Pointposition.X - (markerSize / 2, position.Y - markerSize / 2), new Point(position.X + markerSize / 2, position.Y - markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + markerSize / 2, position.Y - markerSize / 2), new Point(position.X, position.Y + markerSize / 2), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y + markerSize / 2), new Point(position.X - markerSize / 2, position.Y - markerSize / 2), color, thickness, line_type);
            break;
    }
}
You will also need to add an `enum` for `markerType` just like the one in [OpenCV's imgproc.hpp
][2] lines 825 to 837.
C#
/// <summary>
/// Possible set of marker types used for the DrawMarker function
/// </summary>
enum MarkerType
{
    /// <summary>
    /// A crosshair marker shape
    /// </summary>
    MarkerCross = 0,
    /// <summary>
    /// A 45 degree tilted crosshair marker shape
    /// </summary>
    MarkerTiltedCross = 1,
    /// <summary>
    /// A star marker shape, combination of cross and tilted cross
    /// </summary>
    MarkerStar = 2,
    /// <summary>
    /// A diamond marker shape
    /// </summary>
    MarkerDiamond = 3,
    /// <summary>
    /// A square marker shape
    /// </summary>
    MarkerSquare = 4,
    /// <summary>
    /// An upwards pointing triangle marker shape
    /// </summary>
    MarkerTriangleUp = 5,
    /// <summary>
    /// A downwards pointing triangle marker shape
    /// </summary>
    MarkerTriangleDown = 6
}
  [1]: https://github.com/opencv/opencv/blob/master/modules/imgproc/src/drawing.cpp
  [2]: https://github.com/opencv/opencv/blob/master/modules/imgproc/include/opencv2/imgproc.hpp
