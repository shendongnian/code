    public class Module: IHttpModule {
        IRepository repository;
        public void Init(HttpApplication context) {
            IHasRepository application = context as IHasRepository;
            if (application != null) {
                repository = application.Repository;
            }
        }
    }
