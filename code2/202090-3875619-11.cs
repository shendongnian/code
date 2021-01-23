    public static bool NearlyEqual(double a, double b, double epsilon)
    {
        const double MinNormal = 2.2250738585072014E-308d;
        double absA = Math.Abs(a);
        double absB = Math.Abs(b);
        double diff = Math.Abs(a - b);
        if (a.Equals(b))
        { // shortcut, handles infinities
            return true;
        } 
        else if (a == 0 || b == 0 || diff < MinNormal) 
        {
            // a or b is zero or both are extremely close to it
            // relative error is less meaningful here
            return diff < (epsilon * MinNormal);
        }
        else
        { // use relative error
            return diff / (absA + absB) < epsilon;
        }
    }
