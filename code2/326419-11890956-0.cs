    public interface IProjector
        {
            PointD Deproject(PointD projectedCoordinate);
            PointD Project(PointD geographicCoordinate);
            PointD Project(Position position);
            PointD Project(Latitude latitude, Longitude longitude);
        }
    
    [StructLayout(LayoutKind.Sequential)]
        public struct PointD : IEquatable<PointD>, IFormattable
        {
            private double _x;
            private double _y;
            public static PointD Empty;
            public PointD(double x, double y)
            {
                this._x = x;
                this._y = y;
            }
    
            public PointD(PointD p)
            {
                this._x = p.X;
                this._y = p.Y;
               
            }
    
            public double X
            {
                get
                {
                    return this._x;
                }
                set
                {
                    this._x = value;
                }
            }
            public double Y
            {
                get
                {
                    return this._y;
                }
                set
                {
                    this._y = value;
                }
            }
            public bool IsEmpty
            {
                get
                {
                    return this.Equals(Empty);
                }
            }
            public Point ToPoint()
            {
                return new Point((int)this._x, (int)this._y);
            }
    
            public void Normalize()
            {
                double num = Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
                this.X /= num;
                this.Y /= num;
            }
    
            public static PointD FromSize(Size size)
            {
                return new PointD((double)size.Width, (double)size.Height);
            }
    
            public static PointD FromSize(SizeF size)
            {
                return new PointD((double)size.Width, (double)size.Height);
            }
    
            public static bool operator ==(PointD left, PointD right)
            {
                return left.Equals(right);
            }
    
            public static bool operator !=(PointD left, PointD right)
            {
                return !left.Equals(right);
            }
    
            public static PointD operator -(PointD left, PointD right)
            {
                return new PointD(left.X - right.X, left.Y - right.Y);
            }
    
            public override bool Equals(object obj)
            {
                return ((obj is PointD) && this.Equals((PointD)obj));
            }
    
            public override int GetHashCode()
            {
                return (this._x.GetHashCode() ^ this._y.GetHashCode());
            }
    
            public override string ToString()
            {
                return this.ToString("G", CultureInfo.CurrentCulture);
            }
    
            public bool Equals(PointD other)
            {
                return (this._x.Equals(other.X) && this._y.Equals(other.Y));
            }
    
            public string ToString(string format, IFormatProvider formatProvider)
            {
                CultureInfo info = (CultureInfo)formatProvider;
                return (this._x.ToString(format, formatProvider) + info.TextInfo.ListSeparator + " " + this._y.ToString(format, formatProvider));
            }
    
            static PointD()
            {
                Empty = new PointD(0.0, 0.0);
            }
        }
    
    public class Projector : IProjector
        {
            
    
            private const double DEGREEStoRADIANS = System.Math.PI / 180;
            private const double RADIANStoDEGREES = 180 / System.Math.PI;
    
            /* These values represent the equatorial radius of the WGS84 ellipsoid in meters.
             * resulting in projected coordinates which are also in meters
             */
            private const double WGS84SEMIMAJOR = 6378137.0;
            private const double ONEOVERWGS84SEMIMAJOR = 1.0 / WGS84SEMIMAJOR;
    
           
            
            public PointD Deproject(PointD projectedCoordinate)
            {
         
                .PointD result = new PointD();
    
                // Calculate the geographic X coordinate (longitude)
                result.X = (float)(projectedCoordinate.X * ONEOVERWGS84SEMIMAJOR / System.Math.Cos(0) * RADIANStoDEGREES);
    
                // Calculate the geographic Y coordinate (latitude)
                result.Y = (float)(projectedCoordinate.Y * ONEOVERWGS84SEMIMAJOR * RADIANStoDEGREES);
                
                return result;
            }
    
            public PointD Project(PointD geographicCoordinate)
            {
          
              PointD result = new PointD();
    
                // Calculate the projected X coordinate
                result.X = (float)(geographicCoordinate.X * DEGREEStoRADIANS * System.Math.Cos(0) * WGS84SEMIMAJOR);
    
                // Calculate the projected Y coordinate
                result.Y = (float)(geographicCoordinate.Y * DEGREEStoRADIANS * WGS84SEMIMAJOR);
    
                // Return the result
                return result;       
    
            }
    
            public PointD Project(Position position)
            {
               PointD td = new PointD();
                td.X = ((position.Latitude.DecimalDegrees * DEGREEStoRADIANS) * System.Math.Cos(0.0)) * WGS84SEMIMAJOR;
                td.Y = (position.Longitude.DecimalDegrees * DEGREEStoRADIANS) * WGS84SEMIMAJOR;
                return td;
            }
    
            public PointD Project(Latitude latitude, Longitude longitude)
            {
                PointD td = new RTGeoFramework.Math.PointD();
                td.X = ((latitude.DecimalDegrees * DEGREEStoRADIANS) * System.Math.Cos(0.0)) * WGS84SEMIMAJOR;
                td.Y = (longitude.DecimalDegrees * DEGREEStoRADIANS) * WGS84SEMIMAJOR;
                return td;
            }
             
        }
