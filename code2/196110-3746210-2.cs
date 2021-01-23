    public interface IMathAlgorithm
    {
        double Add(double a, double b);
    }
    
    public class FooAlgorithm : IMathAlgorithm
    {
        public double Add(double a, double b)
        {
            return StaticFoo.Add(a, b);
        }
    }
    
    public class BarAlgorithm : IMathAlgorithm
    {
        public double Add(double a, double b)
        {
            return StaticBar.Add(a, b);
        }
    }
