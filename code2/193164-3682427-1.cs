    public Func<T, double> ComputeBasicAmount<T>(double basicLimit,
                                                 Func<T, double> multiplier)
    {    
        return item => basicLimt * multiplier(item);
    }
    ...
    var basicAmtFunc = ComputeBasicAmount<Foo>(
                            foo.BasicLimit,
                            x => x.EligibleAmt / x.RoomRate);
    var basicAmt = basicAmntFunc(foo);
