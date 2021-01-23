    namespace MyTouchPoint 
    {
    class TouchPoint
    {
    public Point Position = new Point (0,0);
    public TouchDevice TouchDevice = new TouchDevice();
    TouchPoint (int id_, Point position_) 
    {
        TouchDevice.Id = id_;
        Position = position_;
    }
    };
    class TouchDevice
    {
    public int Id = 0;
    };
    } // end namespace
