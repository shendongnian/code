    public static string ToStringWithOffset(this DateTime dt)
    {
      return new DateTimeOffset(dt).ToStringWithOffset();
    }
    
    public static string ToStringWithOffset(this DateTime dt, TimeSpan offset)
    {
      return new DateTimeOffset(dt, offset).ToStringWithOffset();
    }
    
    public static string ToStringWithOffset(this DateTimeOffset dt)
    {
      string sign = dt.Offset < TimeSpan.Zero ? "-" : "+";
      int hours = Math.Abs(dt.Offset.Hours);
      int minutes = Math.Abs(dt.Offset.Minutes);
  
      return string.Format("{0:yyyyMMddHHmmss}{1}{2:00}{3:00}", dt, sign, hours, minutes);
    }
