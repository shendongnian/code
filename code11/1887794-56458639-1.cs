    /// <summary>
    /// Total price for this line without VAT
    /// </summary>
    public float PriceTotalWithoutVAT
    {
    	get
    	{
    		return (float)Math.Round(this.Qtd * (this.PricePerUnit - (this.PricePerUnit * (this.Discount / 100))), 2);
    	}
    }
    /// <summary>
    /// Returns the value of <seealso cref="PriceTotalWithoutVAT"/> as string with only 2 decimal places
    /// </summary>
    public string GetPriceTotalWithoutVat
    {
    	get
    	{
    		return this.PriceTotalWithoutVAT.ToString("0.00") + RegionInfo.CurrentRegion.CurrencySymbol;
    	}
    }
