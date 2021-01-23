    internal class OtherClass : BaseClass , ITest 
    {
        double ITest.MethodC(double a, double b, double c, double d)
        {
            return base.MethodC(a, b, c, d)
        }
    }
    
