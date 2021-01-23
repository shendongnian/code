    public interface IMeasurable
    {
        someReturnType GetMeasure();
    }
    
    public class Circle : IMeasurable
    {
        //some other methods
    
        public someReturnType GetMeasure() { return GetArea(); }
    }
    
    public class Cube : IMeasurable
    {
        //some other methods
    
        public someReturnType GetMeasure() { return GetVolume(); }
    }
