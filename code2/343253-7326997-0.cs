    public static int UBound(Array array, int dimension)
    {
        if (Array == null)
        {
            throw new ArgumentNullException("array");
        }
    
        return array.GetUpperBound(dimension-1);
    }
 
