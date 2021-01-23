    public class JobDefectsController : DefectsController<JobDefect, IEntityService<JobDefect>>
    {
        public JobDefectsController(IEntityService<JobDefect> service)
            : base(service)
        {
        }
    }
