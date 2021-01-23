    public double ComputeBasicAmount<T>(double basicLimit,
                                        Func<T, double> multiplier,
                                        T item)
    {    
        return basicLimt * multiplier(item);
    }
    ...
    double basicAmt = ComputeBasicAmount<Foo>(
                            foo.BasicLimit,
                            x => x.EligibleAmt / x.RoomRate,
                            foo)
