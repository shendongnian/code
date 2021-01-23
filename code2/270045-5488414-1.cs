    public class HomeController : Controller
    {
      public ActionResult Index()
      {
        MyDataContext dc = new MyDataContext();
        MyPageViewModel vm = new MyPageViewModel();
        vm.Table1Data =  from n in dc.Table1                     
                         select n;
        vm.Table1Data = from k in dc.Table2        
                        select k;
        return View(vm);
      }
    }
