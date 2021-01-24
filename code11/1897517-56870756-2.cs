[HttpGet("{calendarName}/{id}")]
public void ActionResult GetCalendar(string calendarName, int id)
{
    ...
}
Or if you want to pass the as a optional query
[HttpGet("{calendarName}")]
public void ActionResult GetCalendar(string calendarName, [FromQuery]int id)
{
    ...
}
