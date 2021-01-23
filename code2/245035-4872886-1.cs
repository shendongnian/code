    public class DepartmentsController : Controller
    {
      private IDepartmentsRepository _departmentsRepository;
      [Inject]
      public IDepartmentsRepository DepartmentsRepository
      {
        get { return _departmentsRepository; }
        set { _departmentsRepository = value; }
      }
      public DepartmentsController()
      {
        NinjectHelper.Kernel.Inject(this);
      }
    }
