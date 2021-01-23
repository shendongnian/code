    using System.Linq;
    /// <summary>
    ///     Cubic spline interpolation for tabular data
    /// </summary>
    /// <remarks>
    ///     Adapted from numerical recipies for FORTRAN 77 
    ///     (ISBN 0-521-43064-X), page 110, section 3.3.
    ///     Function spline(x,y,yp1,ypn,y2) converted to 
    ///     C# by jalexiou, 27 November 2007.
    ///     Spline integration added also Nov 2007.
    /// </remarks>
    public class CubicSpline 
    {
        double[] xi;
        double[] yi;
        double[] yp;
        double[] ypp;
        double[] yppp;
        double[] iy;
        #region Constructors
        public CubicSpline(double x_min, double x_max, double[] y)
            : this(Sequence(x_min, x_max, y.Length), y)
        { }
        public CubicSpline(double x_min, double x_max, double[] y, double yp1, double ypn)
            : this(Sequence(x_min, x_max, y.Length), y, yp1, ypn)
        { }
        public CubicSpline(double[] x, double[] y)
            : this(x, y, double.NaN, double.NaN)
        { }
        public CubicSpline(double[] x, double[] y, double yp1, double ypn)
        {
            if( x.Length == y.Length )
            {
                int N = x.Length;
                xi = new double[N];
                yi = new double[N];
                x.CopyTo(xi, 0);
                y.CopyTo(yi, 0);
                if( N > 0 )
                {
                    double p, qn, sig, un;
                    ypp = new double[N];
                    double[] u = new double[N];
                    if( double.IsNaN(yp1) )
                    {
                        ypp[0] = 0;
                        u[0] = 0;
                    }
                    else
                    {
                        ypp[0] = -0.5;
                        u[0] = (3 / (xi[1] - xi[0])) * 
                              ((yi[1] - yi[0]) / (x[1] - x[0]) - yp1);
                    }
                    for (int i = 1; i < N-1; i++)
                    {
                        double hp = x[i] - x[i - 1];
                        double hn = x[i + 1] - x[i];
                        sig = hp / hn;
                        p = sig * ypp[i - 1] + 2.0;
                        ypp[i] = (sig - 1.0) / p;
                        u[i] = (6 * ((y[i + 1] - y[i]) / hn) - (y[i] - y[i - 1]) / hp)
                            / (hp + hn) - sig * u[i - 1] / p;
                    }
                    if( double.IsNaN(ypn) )
                    {
                        qn = 0;
                        un = 0;
                    }
                    else
                    {
                        qn = 0.5;
                        un = (3 / (x[N - 1] - x[N - 2])) * 
                              (ypn - (y[N - 1] - y[N - 2]) / (x[N - 1] - x[N - 2]));
                    }
                    ypp[N - 1] = (un - qn * u[N - 2]) / (qn * ypp[N - 2] + 1.0);
                    for (int k = N-2; k > 0; k--)
                    {
                        ypp[k] = ypp[k] * ypp[k + 1] + u[k];
                    }
                    // Calculate 1st derivatives
                    yp = new double[N];
                    double h;
                    for( int i = 0; i < N - 1; i++ )
                    {
                        h = xi[i + 1] - xi[i];
                        yp[i] = (yi[i + 1] - yi[i]) / h
                               - h / 6 * (ypp[i + 1] + 2 * ypp[i]);
                    }
                    h = xi[N - 1] - xi[N - 2];
                    yp[N - 1] = (yi[N - 1] - yi[N - 2]) / h
                                 + h / 6 * (2 * ypp[N - 1] + ypp[N - 2]);
                    // Calculate 3rd derivatives as average of dYpp/dx
                    yppp = new double[N];
                    double[] jerk_ij = new double[N - 1];
                    for( int i = 0; i < N - 1; i++ )
                    {
                        h = xi[i + 1] - xi[i];
                        jerk_ij[i] = (ypp[i + 1] - ypp[i]) / h;
                    }
                    Yppp = new double[N];
                    yppp[0] = jerk_ij[0];
                    for( int i = 1; i < N - 1; i++ )
                    {
                        yppp[i] = 0.5 * (jerk_ij[i - 1] + jerk_ij[i]);
                    }
                    yppp[N - 1] = jerk_ij[N - 2];
                    // Calculate Integral over areas
                    iy = new double[N];
                    yi[0] = 0;  //Integration constant
                    for( int i = 0; i < N - 1; i++ )
                    {
                        h = xi[i + 1] - xi[i];
                        iy[i + 1] = h * (yi[i + 1] + yi[i]) / 2
                                 - h * h * h / 24 * (ypp[i + 1] + ypp[i]);
                    }
                }
                else
                {
                    yp = new double[0];
                    ypp = new double[0];
                    yppp = new double[0];
                    iy = new double[0];
                }
            }
            else
                throw new IndexOutOfRangeException();
        }
        #endregion
        #region Actions/Functions
        public int IndexOf(double x)
        {
            //Use bisection to find index
            int i1 = -1;
            int i2 = Xi.Length;
            int im;
            double x1 = Xi[0];
            double xn = Xi[Xi.Length - 1];
            bool ascending = (xn >= x1);
            while( i2 - i1 > 1 )
            {
                im = (i1 + i2) / 2;
                double xm = Xi[im];
                if( ascending & (x >= Xi[im]) ) { i1 = im; } else { i2 = im; }
            }
            if( (ascending && (x <= x1)) || (!ascending & (x >= x1)) )
            {
                return 0;
            }
            else if( (ascending && (x >= xn)) || (!ascending && (x <= xn)) )
            {
                return Xi.Length - 1;
            }
            else
            {
                return i1;
            }
        }
        public double GetIntY(double x)
        {
            int i = IndexOf(x);
            double x1 = xi[i];
            double x2 = xi[i + 1];
            double y1 = yi[i];
            double y2 = yi[i + 1];
            double y1pp = ypp[i];
            double y2pp = ypp[i + 1];
            double h = x2 - x1;
            double h2 = h * h;
            double a = (x-x1)/h;
            double a2 = a*a;
            return h / 6 * (3 * a * (2 - a) * y1 
                     + 3 * a2 * y2 - a2 * h2 * (a2 - 4 * a + 4) / 4 * y1pp
                     + a2 * h2 * (a2 - 2) / 4 * y2pp);
        }
        public double GetY(double x)
        {
            int i = IndexOf(x);
            double x1 = xi[i];
            double x2 = xi[i + 1];
            double y1 = yi[i];
            double y2 = yi[i + 1];
            double y1pp = ypp[i];
            double y2pp = ypp[i + 1];
            double h = x2 - x1;
            double h2 = h * h;
            double A = 1 - (x - x1) / (x2 - x1);
            double B = 1 - A;
            
            return A * y1 + B * y2 + h2 / 6 * (A * (A * A - 1) * y1pp
                         + B * (B * B - 1) * y2pp);
        }
        public double GetYp(double x)
        {
            int i = IndexOf(x);
            double x1 = xi[i];
            double x2 = xi[i + 1];
            double y1 = yi[i];
            double y2 = yi[i + 1];
            double y1pp = ypp[i];
            double y2pp = ypp[i + 1];
            double h = x2 - x1;
            double A = 1 - (x - x1) / (x2 - x1);
            double B = 1 - A;
            return (y2 - y1) / h + h / 6 * (y2pp * (3 * B * B - 1)
                       - y1pp * (3 * A * A - 1));
        }
        public double GetYpp(double x)
        {
            int i = IndexOf(x);
            double x1 = xi[i];
            double x2 = xi[i + 1];
            double y1pp = ypp[i];
            double y2pp = ypp[i + 1];
            double h = x2 - x1;
            double A = 1 - (x - x1) / (x2 - x1);
            double B = 1 - A;
            return A * y1pp + B * y2pp;
        }
        public double GetYppp(double x)
        {
            int i = IndexOf(x);
            double x1 = xi[i];
            double x2 = xi[i + 1];
            double y1pp = ypp[i];
            double y2pp = ypp[i + 1];
            double h = x2 - x1;
            return (y2pp - y1pp) / h;
        }
        public double Integrate(double from_x, double to_x)
        {
            if( to_x < from_x ) { return -Integrate(to_x, from_x); }
            int i = IndexOf(from_x);
            int j = IndexOf(to_x);
            double x1 = xi[i];
            double xn = xi[j];
            double z = GetIntY(to_x) - GetIntY(from_x);    // go to nearest nodes (k) (j)
            for( int k = i + 1; k <= j; k++ )
            {
                z += iy[k];                             // fill-in areas in-between
            }            
            return z;
        }
        #endregion
        #region Properties
        public bool IsEmpty { get { return xi.Length == 0; } }
        public double[] Xi { get { return xi; } set { xi = value; } }
        public double[] Yi { get { return yi; } set { yi = value; } }
        public double[] Yp { get { return yp; } set { yp = value; } }
        public double[] Ypp { get { return ypp; } set { ypp = value; } }
        public double[] Yppp { get { return yppp; } set { yppp = value; } }
        public double[] IntY { get { return yp; } set { iy = value; } }
        public int Count { get { return xi.Length; } }
        public double X_min { get { return xi.Min(); } }
        public double X_max { get { return xi.Max(); } }
        public double Y_min { get { return yi.Min(); } }
        public double Y_max { get { return yi.Max(); } }
        #endregion
        #region Helpers
        static double[] Sequence(double x_min, double x_max, int double_of_points)
        {
            double[] res = new double[double_of_points];
            for (int i = 0; i < double_of_points; i++)
            {
                res[i] = x_min + (double)i / (double)(double_of_points - 1) * (x_max - x_min);
            }
            return res;
        }
        
        #endregion
    }
