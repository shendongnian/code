    public class ServerFilterProvider : IJobFilterProvider
    {
        public IEnumerable<JobFilter> GetFilters(Job job)
        {
            return new JobFilter[]
                       {
                           new JobFilter(new CaptureCultureAttribute(), JobFilterScope.Global, null),
                           new JobFilter(new ServerTenantFilter (), JobFilterScope.Global,  null),
                       };
        }
    }
