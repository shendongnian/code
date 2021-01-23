    int FirstHalfTableComparison(FirstHalfTable t1, FirstHalfTable t2)
    {
        int result = t1.FirstHalfPoints.CompareTo(t2.FirstHalfPoints);
        
        if (result == 0)
        {
            result = t1.GD.CompareTo(t2.GD);
        
            if (result == 0)
                result = t1.GF.CompareTo(t2.GF);
        }
        
        return result;
    }
