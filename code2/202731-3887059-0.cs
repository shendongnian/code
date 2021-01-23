    public interface IPoint
    {}
    public interface IControlPoint : IPoint
    {
        // added functionality of IControlPoint
    }
    public interface ILine<TPoint>
        where TPoint : IPoint
    {
        TPoint Start { get; set; }
        TPoint End { get; set; }
    }
    public interface ICurve<TPoint> : ILine<TPoint>
        where TPoint : IPoint
    {
        // added functionality of ICurve
    }
