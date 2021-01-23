public static DateTime RoundUp(this DateTime dt, TimeSpan d)
{
    var delta = (d.Ticks - (dt.Ticks % d.Ticks)) % d.Ticks;
    return new DateTime(dt.Ticks + delta);
}
public static DateTime RoundDown(this DateTime dt, TimeSpan d)
{
    var delta = dt.Ticks % d.Ticks;
    return new DateTime(dt.Ticks - delta);
}
public static DateTime RoundToNearest(this DateTime dt, TimeSpan d)
{
    var delta = dt.Ticks % d.Ticks;
    bool roundUp = delta > d.Ticks / 2;
    
    return roundUp ? dt.RoundUp(d) : dt.RoundDown(d);
}
