    private decimal _subTotal;
    private decimal _shipping;
    private CurrencyIsoCode _currency;
    
    public virtual Money SubTotal
    {
    	get { return new Money(_subTotal, _currency); }
    	set
    	{
    		_subTotal = value.Amount;
    		_currency = value.CurrencyCode;
    	}
    }
    
    public virtual Money Shipping
    {
    	get { return new Money(_shipping, _currency); }
    	set
    	{
    		_shipping = value.Amount;
    		_currency = value.CurrencyCode;
    	}
    }
