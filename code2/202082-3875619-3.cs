    public bool NearlyEqual(double a, double b, double epsilon)
    {
        double absA = Math.Abs(a);
        double absB = Math.Abs(b);
        double diff = Math.Abs(a - b);
        if (a == b)
        { // shortcut, handles infinities
            return true;
        } 
        else if (a == 0 || b == 0 || diff < Double.MinValue) 
        {
            // a or b is zero or both are extremely close to it
            // relative error is less meaningful here
            return diff < (epsilon * Double.MinValue);
        }
        else
        { // use relative error
            return diff / (absA + absB) < epsilon;
        }
    }
