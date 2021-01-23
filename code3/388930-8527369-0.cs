    private catalogProductTierPriceEntity[] addTierPrices(List<V_prices> prices)
    {
        catalogProductTierPriceEntity[] mageTierPrices = new catalogProductTierPriceEntity[3];
        catalogProductTierPriceEntity mageTierPrice;
    
        int i = 0;
        foreach (V_prices price in prices)
        {
            mageTierPrice = new catalogProductTierPriceEntity();
            mageTierPrice.website = "all";
            mageTierPrice.customer_group_id = "all";
            mageTierPrice.qty = price.quantity;
            mageTierPrice.price = (double)price.value; // Conversion from decimal
            mageTierPrices[i] = mageTierPrice;
    // FIX:
            mageTierPrice.priceSpecified = true;
            mageTierPrice.qtySpecified = true;
            i++;
        }
    
        return mageTierPrices;
    }
