C#
/// <summary>
/// Adding a set of predefined markers which could be used to highlight positions in an image
/// <summary>
private void DrawMarker(IInputOutputArray img, Point position, MCvScalar color, MarkerTypes markerType, int markerSize, int thickness, LineType line_type)
{
    switch (markerType)
    {
        // The cross marker case
        case MarkerTypes.MARKER_CROSS:
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y), new Point(position.X + (markerSize / 2), position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y - (markerSize / 2)), new Point(position.X, position.Y + (markerSize / 2)), color, thickness, line_type);
            break;
        // The tilted cross marker case
        case MarkerTypes.MARKER_TILTED_CROSS:
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X + (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X - (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            break;
        // The star marker case
        case MarkerTypes.MARKER_STAR:
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y), new Point(position.X + (markerSize / 2), position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y - (markerSize / 2)), new Point(position.X, position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X + (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X - (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            break;
        // The diamond marker case
        case MarkerTypes.MARKER_DIAMOND:
            CvInvoke.Line(img, new Point(position.X, position.Y - (markerSize / 2)), new Point(position.X + (markerSize / 2), position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + (markerSize / 2), position.Y), new Point(position.X, position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y + (markerSize / 2)), new Point(position.X - (markerSize / 2), position.Y), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y), new Point(position.X, position.Y - (markerSize / 2)), color, thickness, line_type);
            break;
        // The square marker case
        case MarkerTypes.MARKER_SQUARE:
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X + (markerSize / 2), position.Y - (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X + (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + (markerSize / 2), position.Y + (markerSize / 2)), new Point(position.X - (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y + (markerSize / 2)), new Point(position.X - (markerSize / 2), position.Y - (markerSize / 2)), color, thickness, line_type);
            break;
        // The triangle up marker case
        case MarkerTypes.MARKER_TRIANGLE_UP:
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y + (markerSize / 2)), new Point(position.X + (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + (markerSize / 2), position.Y + (markerSize / 2)), new Point(position.X, position.Y - (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y - (markerSize / 2)), new Point(position.X - (markerSize / 2), position.Y + (markerSize / 2)), color, thickness, line_type);
            break;
        // The triangle down marker case
        case MarkerTypes.MARKER_TRIANGLE_DOWN:
            CvInvoke.Line(img, new Point(position.X - (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X + (markerSize / 2), position.Y - (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X + (markerSize / 2), position.Y - (markerSize / 2)), new Point(position.X, position.Y + (markerSize / 2)), color, thickness, line_type);
            CvInvoke.Line(img, new Point(position.X, position.Y + (markerSize / 2)), new Point(position.X - (markerSize / 2), position.Y - (markerSize / 2)), color, thickness, line_type);
            break;
        // If any number that doesn't exist is entered as marker type, draw a cross marker, to avoid crashes
        default:
            DrawMarker(img, position, color, MarkerTypes.MARKER_CROSS, markerSize, thickness, line_type);
            break;
    }
}
You will also need to add an `enum` for `markerType` just like the one in [OpenCV's imgproc.hpp
][2] lines 825 to 837.
C#
/// <summary>
/// Possible set of marker types used for the DrawMarker function
/// </summary>
enum MarkerTypes
{
    /// <summary>
    /// A crosshair marker shape
    /// </summary>
    MARKER_CROSS = 0,
    /// <summary>
    /// A 45 degree tilted crosshair marker shape
    /// </summary>
    MARKER_TILTED_CROSS = 1,
    /// <summary>
    /// A star marker shape, combination of cross and tilted cross
    /// </summary>
    MARKER_STAR = 2,
    /// <summary>
    /// A diamond marker shape
    /// </summary>
    MARKER_DIAMOND = 3,
    /// <summary>
    /// A square marker shape
    /// </summary>
    MARKER_SQUARE = 4,
    /// <summary>
    /// An upwards pointing triangle marker shape
    /// </summary>
    MARKER_TRIANGLE_UP = 5,
    /// <summary>
    /// A downwards pointing triangle marker shape
    /// </summary>
    MARKER_TRIANGLE_DOWN = 6
}
  [1]: https://github.com/opencv/opencv/blob/master/modules/imgproc/src/drawing.cpp
  [2]: https://github.com/opencv/opencv/blob/master/modules/imgproc/include/opencv2/imgproc.hpp
