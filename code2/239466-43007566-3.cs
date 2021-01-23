    /// <summary>
    /// retrieve distinct of given vector set ensuring to maintain given order
    /// </summary>        
    public static IEnumerable<Vector3D> DistinctKeepOrder(this IEnumerable<Vector3D> vectors, Vector3DEqualityComparer cmp)
    {
        var ocmp = new Vector3DWithOrderEqualityComparer(cmp);
    
        return vectors
            .Select((w, i) => new Vector3DWithOrder(w, i))
            .Distinct(ocmp)
            .OrderBy(w => w.Order)
            .Select(w => w.Vector);
    }
