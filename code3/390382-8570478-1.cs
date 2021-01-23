    public static decimal[] SpecialPrice(decimal w, decimal p)
    {
       if (w < p)
       {
          return new decimal[] { p };
       }
       else if(w > p && p > 0)
       {
           return new decimal[] { w, p };
       }
       else
       {
           return new decimal[] { w };
       }
    }
