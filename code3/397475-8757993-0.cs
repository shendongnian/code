    public interface IShape
    {
        string Title { get; }
        string Color { get; }
    }
    public interface I2DShape : IShape
    {
        int GetArea();
    }
    public interface I3DShape : IShape
    {
        int GetVolume();
    }
