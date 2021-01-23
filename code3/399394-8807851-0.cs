public static class DateTimeExtensions
{
    public static string CustomFormat(this DateTime dt)
    {
        // Could use @Brandon's approach or whatever else here.
        return String.Format("{0}h{1}m", dt.Hour, dt.Minute);
    }
}
...
// Usage:
DateTime.Now.CustomFormat();
