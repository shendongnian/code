    public Decimal getPrice()
    {
        Decimal x = 0; 
        using (DAL.Entities siliconContext = new DAL.Entities())
        {
            var result = from d in siliconContext.SILICONs
                         select d.MIN_PRICE;
            var result2 = from d in seliconContext.GLASEs
                          select d.MIN_PRICE;
            //You can then work with results from table GLASE!
            foreach (Decimal d in result)
            {
                x = d;
            }
            return x;
        }
    }
