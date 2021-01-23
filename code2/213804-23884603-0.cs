    public decimal ExchTotalPrice
    {
        get
        {
            RaiseMeWhen(this, has => has.Changed(_ => _.TotalPrice));
            RaiseMeWhen(ExchangeRate, has => has.Changed(_ => _.Rate));
            return TotalPrice * ExchangeRate.Rate;
        }
    }
