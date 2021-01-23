    public decimal SalePrice {
       get{
           return salePrice;
       }
       set {
            if (salePrice != value) {
              salePrice = value; // putting as first statement prevents the setter 
                                 // to be entered again ...
              RaiseSalePriceChange();
              // Set other properties
            }
       }
    }
