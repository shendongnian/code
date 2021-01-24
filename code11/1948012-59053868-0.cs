    public abstract class TController<TEntity, TService> : ControllerBase
        where TEntity : class, IEntity
        where TService : IService<TEntity>
    {
    
        protected readonly TService service;
    
        public TController(TService service)
        {
            this.service = service;
        }
    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await this.service.GetAll();
        }
    
        [Methods GetId, Add, Update, Delete, but cut out to keep the code short]
    
    }
