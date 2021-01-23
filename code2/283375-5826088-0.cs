    public static class ExtensionMethods
    {
        public static double Deg2Rad(this double angle)
        {
            return Math.PI*angle/180.0;
        }
        public static double Pi(this double x)
        {
            return Math.PI*x;
        }
    }
