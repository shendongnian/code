csharp
class TestRepo
{
    public IEnumerable<DateTime> GetDates()
    {
        var now = DateTime.Now;
        // Use DateTime instances with different Kind
        // showing that it doesn't impact the serialization format.
        var utc = DateTime.SpecifyKind(new DateTime(now.Ticks), DateTimeKind.Utc);
        var local = DateTime.SpecifyKind(new DateTime(now.Ticks), DateTimeKind.Local);
        var unspecified = DateTime.SpecifyKind(new DateTime(now.Ticks), DateTimeKind.Unspecified);
        return new DateTime[] { utc, local, unspecified };
    }
}
csharp
// MVC controller
public class MVCValuesController : Controller
{
    public ActionResult Index()
    {
        IEnumerable<DateTime> dates = new TestRepo().GetDates();
        return Json(dates, JsonRequestBehavior.AllowGet);
    }
}
// json result:
[
    "/Date(1563465361835)/",
    "/Date(1563458161835)/",
    "/Date(1563458161835)/"
]
csharp
// Web API controller
public class ValuesController : ApiController
{
    public IEnumerable<DateTime> Get()
    {
        IEnumerable<DateTime> dates = new TestRepo().GetDates();
        return dates;
    }
}
// json result:
[
    "2019-07-18T15:56:03.6401158Z",
    "2019-07-18T15:56:03.6401158+02:00",
    "2019-07-18T15:56:03.6401158"
]
  [1]: https://davidsekar.com/javascript/converting-json-date-string-date-to-date-object
  [2]: https://stackoverflow.com/questions/14591750/setting-the-default-json-serializer-in-asp-net-mvc
  [3]: https://stackoverflow.com/questions/7109967/using-json-net-as-the-default-json-serializer-in-asp-net-mvc-3-is-it-possible
  [4]: https://stackoverflow.com/questions/23995210/how-to-use-json-net-for-json-modelbinding-in-an-mvc5-project
