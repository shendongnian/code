    public static class Utils
    {
       public static int Size(this double n)
       {
         int i = (int)Math.Abs(n);
         if ( i == 0 ) return 0;
         return  i.ToString().Length;
       }
    }
    12.324654.Size() == 2;
