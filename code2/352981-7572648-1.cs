    public HomeController() :
       this(new externalEntities(),
       new MyEntitiesRepository (new MyEntities()))
    {
    }
    
    public HomeController(externalEntities external, MyEntitiesRepository repository)
    {
       _repository = repository;
       _ContextExt = external;
    }
    public partial class MyEntitiesRepository 
    {
        public MyEntitiesRepository(IMyEntities context)
        {
            this.Context = context;
        }
        public IMyEntities Context { get; private set; }
    }
