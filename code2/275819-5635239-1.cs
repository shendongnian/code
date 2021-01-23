    public class JobDefectsController : DefectsController<JobDefect, EntityService<JobDefect>>
    {
        public JobDefectsController(EntityService<JobDefect> service)
            : base(service)
        {
        }
    }
