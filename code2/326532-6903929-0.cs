    void Main()
    {
        var x = -0.00160231155763821;
        var x2 = 0.099;
        var x3 = -0.001;
    	
        x.G2Format().Dump("x");
        x2.G2Format().Dump("x2");
        x3.G2Format().Dump("x3");
    }
    
    public static class Extensions
    {
        public static string G2Format(this double value)
        {
            var format = (0.01 > value) ? "{0:e}" : "{0:G}";
            return string.Format(format, value);
        }
    }
