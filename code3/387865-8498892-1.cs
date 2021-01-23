    public static decimal? ComparePrice(decimal Price, decimal WebsitePrice)
        {
            if(Price == decimal.Zero && WebsitePrice > decimal.Zero){
                return WebsitePrice;
            }else if(Price == decimal.Zero && WebsitePrice == decimal.Zero){
                return null;
            }else{
                return Price;
            }
    
        }
