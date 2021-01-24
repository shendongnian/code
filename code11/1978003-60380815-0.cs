    public static IQueryable<BidPhase> GetPhaseSet(BidDatabase ctx)
    {
        var t = typeof(BidDatabase);
        var setMethod = t.GetMethod("Set");
        var setMethodSpecific = setMethod.MakeGenericMethod(new Type[] { typeof(BidPhaseLh2) }); 
        var dbSet = setMethodSpecific.Invoke(ctx, null);
        return (IQueryable<BidPhase>)dbSet;
    }
