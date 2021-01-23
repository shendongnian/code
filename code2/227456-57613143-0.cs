    public interface ITest
    {
        double MethodC(double a, double b, double c, double d);
    }
    internal class BaseClass
    {
        public double MethodC(double a, double b, double c, double d)
        {
            return a+b+c+d;
        }
    }
    internal class OtherClass : BaseClass , ITest 
    {
    }
