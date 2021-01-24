    /// <summary>
    /// Quantity for the line
    /// </summary>
    public float Qtd
    {
    	get
    	{
    		return this._qtd;
    	}
    	set
    	{
    		this._qtd = value;
    		NotifyPropertyChanged("Qtd");
    		NotifyPropertyChanged("PriceTotalWithoutVAT");
    		NotifyPropertyChanged("GetPriceTotalWithoutVat");
    		NotifyPropertyChanged("PriceTotalWithVAT");
    		NotifyPropertyChanged("GetPriceTotalWithVAT");
    	}
    }
