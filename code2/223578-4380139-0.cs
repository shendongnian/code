    public interface ICircle
    {
        Point Point{get;}
        uint Radius{get;}
        ... add whatever you need
    }
    
    public class MyCircle: ICircle
    {
       private Circle _circle;
       ... implement interface
    }
    
    public class MyCircle2: ICircle
    {
       private Point _point;
       private uint _radius;
       ... implement interface
    }
    
    void Run<T>(T circle) where T: ICircle
    {
        if(AllNegative(circle))
        {
            ColorCircle(circle);
        }
    }
