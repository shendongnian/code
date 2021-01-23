    private void Compare(YourRow a, YourRow b)
    {
       let v = a.FirstHalfPoints.CompareTo(b.FirstHalfPoints);
       if (v != 0) return v;
    
       v = a.GD.CompareTo(b.GD);
       if (v != 0) return v;
    
       return a.GF.CompareTo(b.GF);
    }
