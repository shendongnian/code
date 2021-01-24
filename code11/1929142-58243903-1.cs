    public static string BuyOneGetOneFree(KartItem inKart)
    {  
        if (inKart.Item == "Lettuce" || inKart.Item == "Pespsi" || inKart.Item == "Water")
        {
            double newCost = inKart.Cost * 2;
            inKart.Cost = newCost;
            return "Your get one buy one credit applied today ! " + newCost.ToString();
        }
        return "There is no discount for your item at this time";
    }
