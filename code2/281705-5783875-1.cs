    public string ProductType
    {
        get { return productType; }
        set
        {
            if ( productType == value )
                return;
            productType = value;
            // update ColorProductType here
            RaisePropertyChanged("ProductType");
        }
    }
