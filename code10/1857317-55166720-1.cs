    public class OrgStructureService : IOrgStructureService
    {
        private readonly ITContext _context;
        private readonly ISession _session;
        public OrgStructureService(ITContext context, IHttpContextAccessor httpContextAccessor)
            : base(builder)
        {
            _context = context;
            _session = httpContextAccessor.HttpContext.Session;
        }
