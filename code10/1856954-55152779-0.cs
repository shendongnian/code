    interface IShape 
    {
        double X { get; }
        double Y { get; }
    }
    
    interface IAreaShape : IShape
    {
        double GetArea();
    }
    
    interface IPerimeterShape : IShape
    {
        double GetPerimeter();
    }
