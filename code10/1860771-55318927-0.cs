    public static class Extensions
    {
         public static long MilliSeccondsSinceEpoch(this DateTime d)
         {
             DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
             return (d - Epoch).TotalMillisecond;
         }
    }
