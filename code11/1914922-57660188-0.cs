public class MyService : IService 
{
 public MyService(EmployeeContext context)
 {
  // ...
 }
}
public class EmployeeController : Controller
{
    private EmployeeContext _context;
    private _myService;
    public EmployeeController(EmployeeContext context, IMyService myService)
    {
        _context = context;
        _myService = myService;
    }
    public ActionResult Index()
    {
        return View(context.Employees.ToList());
    }
    ...//other action methods that access context's DbSet
}
