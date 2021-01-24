    public class OrgStructureService : ITContext, IOrgStructureService
    {
        ...
        public OrgStructureService(DbContextOptionsBuilder builder, IHttpContextAccessor httpContextAccessor)
            : base(builder)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }
