    public class Length
    {
        private double const MillimetersPerInch = 25.4;
        private double Millimeters;
        public static Length FromMillimeters(double mm)
        {
             Millimeters = mm;
        }
        public static Length FromInch(double inch)
        {
             Millimeters = inch * MillimetersPerInch;
        }
        public double Inch { get { return Millimeters / MillimetersPerInch; } } 
        public double Millimeters { get { return Millimeters; } }
    }
