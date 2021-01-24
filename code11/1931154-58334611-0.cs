    public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }
            // override object.Equals
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }
                Point obj1 = (Point)obj;
    
                if (Math.Abs(Math.Pow(X - obj1.X, 2) + Math.Pow(Y - obj1.Y, 2) + Math.Pow(Z - obj1.Z, 2)) >= 0.1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
    
            }
        }
