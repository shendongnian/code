    public Decimal getPrice()
    {
        Decimal x = 0;
        using (DAL.Entities siliconContext = new DAL.Entities())
        {
            var result = from d in siliconContext.SILICONs
                         select d.MIN_PRICE;
            foreach (Decimal d in result)
            {
                x = d;
            }
            return x;
        }
    }
