    public abstract class ApplicationController : Controller
    {
        protected readonly IModuleRepository _moduleRepository;
        public IModuleRepository moduleRepository
        {
            get { return _moduleRepository; }
        }
        public ApplicationController()
        {
            this._moduleRepository = DependencyResolver.Current.GetService<IModuleRepository>();
            foreach (var module in _moduleRepository.GetAllModules())
                ViewData[module.name] = module.value;
        }
    }
