    public partial class SampleContext : DbContext
    {
        public SampleContext (): base(...)
        {
            // disable lazy-loading in your db-context
            Configuration.LazyLoadingEnabled = false;
        }
    }
