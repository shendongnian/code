    public interface IMessurable
    {
        someReturnType GetMessure();
    }
    
    public class Circle : IMessurable
    {
        //some other methods
    
        public someReturnType GetMessure() { return GetArea(); }
    }
    
    public class Cube : IMessurable
    {
        //some other methods
    
        public someReturnType GetMessure() { return GetVolume(); }
    }
