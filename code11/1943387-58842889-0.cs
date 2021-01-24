        int decimalPlaces = 2;
        double finalMultiplier = 2.225f;
        finalMultiplier = Math.Round(finalMultiplier,decimalPlaces, MidpointRounding.ToEven);
        //Will round 2.225 to 2.22
        BigInteger cost = new BigInteger(500);
        cost *= ((BigInteger) (finalMultiplier * Math.Pow(10, decimalPlaces))); //Multiply by 222
        cost /= (BigInteger) (Math.Pow(10,decimalPlaces)); //Divide by 100
        print(cost); //1110
    
