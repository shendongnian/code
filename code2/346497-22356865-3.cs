    public class Vexel
    {
        private Koord _origin;
        private double _extent;
        public Koord Origin { get { return _origin; }  set { _origin = value; } }
        public double Extent { get { return _extent; } set { _extent = value; } }
        public string ToString()
        {
            NumberFormatInfo nFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ""
            }; 
            return String.Format(nFormatInfo, "Origin;{0};{1};{2};Extent;{3}", _origin.X, _origin.Y, _origin.Z, _extent);
        }
        public Vexel()
        {
            _origin = new Koord(0,0,0);
            Extent = 0;
        }
        public Vexel(Koord origin, double extent)
        {
            //TODO do some checking
            _origin = origin;
            _extent = extent;
        }
