    [TypeConverter(typeof(KoordConverter))]
    [Serializable]
    public class Koord
    {
        private double p_1;
        private double p_2;
        private double p_3;
        public Koord(double x, double y, double z)
        {
            this.p_1 = x;
            this.p_2 = y;
            this.p_3 = z;
        }
        public string ToString()
        {
            return String.Format("X;{0};Y;{1};Z;{2}", p_1, p_2, p_3);
        }
        public double X { get { return p_1; } }
        public double Y { get { return p_2; } }
        public double Z { get { return p_3; } }
    }
    
