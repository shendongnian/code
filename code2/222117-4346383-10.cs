    public class ApplicationModel
    {
        public Application Application { get; set; }
        public IList<Bank> Banks { get; set; }
        public IList<AccountType> AccountTypes { get; set; }
    }
    public class ApplicationController : Controller
    {
        public ActionResult Index()
        {
            ApplicationListModel model = new ApplicationListModel()
            {
                Applications = RespositoryFactory.ApplicationRepository.GetAll();
            }
            return View(model);
        }
        public ActionResult Details(int id)
        {
            ApplicationModel model = new ApplicationModel()
            {
                Application = RespositoryFactory.ApplicationRepository.Get(id),
                Banks = RespositoryFactory.BankRepository.GetAll(),
                AccountTypes = RespositoryFactory.AccountTypeRepository.GetAll()
            }
            return View(model);
        }
    }
