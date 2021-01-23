    public static decimal[] SpecialPrice(decimal w, decimal p)
    {
       if (w < p)
       {
          return new decimal[1] { p };
       }
       else if(w > p && p > 0)
       {
           return new decimal[2] { w, p };
       }
       else
       {
           return new decimal[1] { w };
       }
    }
