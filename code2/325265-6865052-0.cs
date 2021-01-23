    public static class Utils
    {
       public static int Size(this double n)
       {
        return  ((int)Math.Abs(n)).ToString().Length;
       }
    }
    12.324654.Size() == 2;
