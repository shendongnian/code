    public static string FreeString(this decimal dec)
    {
       if(dec == 0M)
       {
          return "Free";
       }
       else
       {
          return dec.ToString("C");
       }
    }
