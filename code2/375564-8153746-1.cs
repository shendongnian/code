    private bool _accruedInterestSet;
    private decimal? _accruedInterest;
    public decimal? AccruedInterest
    {
        get
        {
            if (this._accruedInterestSet)
            {
                return this._accruedInterest; //don't return .Value in case they set null
            }
            if (this.Result != null)
            {
                return this.GetExchangedCurrencyValue(this.Result.AccruedInterest.GetValueOrDefault(decimal.Zero))    ;
            }
            return null;
        }
        set
        {
            this._accruedInterestSet = true;
            this._AccruedInterest = value;
        }
    }
