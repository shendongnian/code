public class EventItem 
{
    public int Id { get; set; }
    public int Vn { get; set; }
    public DateTime UtcEventDate { get; set; }
    public string TimeZone { get; set; }
    ...
    public DateTime GetLocalTime()
    {
        TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById(this.TimeZone);
        return TimeZoneInfo.ConvertTimeFromUtc(this.UtcEventDate, tzInfo);
    }
}
