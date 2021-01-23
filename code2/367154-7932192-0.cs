    /// <summary>
    /// Compares the current object with another object of the same type.
    /// </summary>
    /// <returns>
    /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>. 
    /// </returns>
    /// <param name="other">An object to compare with this object.</param>
    public int CompareTo(ApproximateValue other)
    {
        // if other is null, we are greater by default in .NET, so return 1.
        if (other == null)
        {
            return 1;
        }
    
        // this is > other
        if (MinValue > other.MaxValue)
        {
            return 1;
        }
    
        // this is < other
        if (MaxValue < other.MinValue)
        {
            return -1;
        }
    
        // "same"-ish
        return 0;
    }
    
    public static bool operator <(ApproximateValue left, ApproximateValue right)
    {
        if (left == null)
        {
            return right != null;
        }
    
        return left.CompareTo(right) < 0;
    }
    
    public static bool operator >(ApproximateValue left, ApproximateValue right)
    {
        if (right == null)
        {
            return left != null;
        }
    
        return right.CompareTo(left) < 0;
    }
