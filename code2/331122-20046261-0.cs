public static DateTime RoundUp(this DateTime dt, TimeSpan d)
{
    return new DateTime(dt.Ticks - (dt.Ticks % d.Ticks) + d.Ticks);
}
public static DateTime RoundDown(this DateTime dt, TimeSpan d)
{
    return new DateTime(dt.Ticks - (dt.Ticks % d.Ticks));
}
public static DateTime RoundToNearest(this DateTime dt, TimeSpan d)
{
    var delta = dt.Ticks % d.Ticks;
    bool roundUp = delta > d.Ticks / 2;
    
    return roundUp ? dt.RoundUp(d) : dt.RoundDown(d);
}
