    public static decimal? ComparePrice(decimal Price, decimal WebsitePrice)
        {
            decimal ZERO_PRICE = 0.00000M;
            if(Price == ZERO_PRICE && WebsitePrice > ZERO_PRICE){
                return WebsitePrice;
            }else if(Price == ZERO_PRICE && WebsitePrice == ZERO_PRICE){
                return null;
            }else{
                return Price;
            }
    
        }
