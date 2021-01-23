    static decimal CountDecimalPlaces(decimal dec)
        {
            if (dec == 0)
                return 0;
            int[] bits = Decimal.GetBits(dec);
            int exponent = bits[3] >> 16;
            int result = exponent;
            long lowDecimal = bits[0] | (bits[1] >> 8);
            while ((lowDecimal % 10) == 0)
            {
                result--;
                lowDecimal /= 10;
            }
            return result;
        }
        Assert.AreEqual(0, DecimalHelper.CountDecimalPlaces(0m));      
        Assert.AreEqual(1, DecimalHelper.CountDecimalPlaces(0.5m));
        Assert.AreEqual(2, DecimalHelper.CountDecimalPlaces(10.51m));
        Assert.AreEqual(13, DecimalHelper.CountDecimalPlaces(10.5123456978563m));
