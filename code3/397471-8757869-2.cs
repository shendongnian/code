    public interface IMeasurable
    {
        someReturnType GetMeasure();
    }
    
    public class Circle : IMessurable
    {
        //some other methods
    
        public someReturnType GetMeasure() { return GetArea(); }
    }
    
    public class Cube : IMessurable
    {
        //some other methods
    
        public someReturnType GetMeasure() { return GetVolume(); }
    }
