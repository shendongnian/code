    public class Blah
    {
        public double A { get; private set; }
        public double B { get; set; }
        public double C { get; set; }
    
        public double CalculateB()
        {
           ...
        }
    
        public double CalculateC()
        {
           ...
        }
    
        public Blah(){}
    
        public Blah(double b, double c)
        {
            this._B = b;
            this._C = c;
        }
    }
