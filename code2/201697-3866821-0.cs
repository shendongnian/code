    public static string FreeString(this decimal dec)
    {
       if(dec == 0.0)
       {
          return "Free";
       }
       else
       {
          return dec.ToString("C");
       }
    }
