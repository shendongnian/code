    public class MyController : Controller
    {
       private IMyServiceThatNeedsDbContext _myService;
    
       public MyController(IMyServiceThatNeedsDbContext myService)
       {
            _myService = myService;
       }
}
