    // this interface will denote any shape that has a starting and ending point
    public interface IShape
    {
        IPoint Start { get; set; }
        IPoint End { get; set; }
    }
    // this interface will allow for specialization of staring end ending points' type
    public interface IShape<TPoint> : IShape
    {
        // note 'new' will be required here most probably, I didn't compile it
        TPoint Start { get; set; }
        TPoint End { get; set; }
    }
    // a line will be a shape descibed by a pair of points; for the sake of 
    public interface ILine : IShape<Point> { }
    // a curve will be a shape described by a pair of control points
    public interface ICurve : IShape<ControlPoint> { }
